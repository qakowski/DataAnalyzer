using ServiceModule.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModule.DataAccess.Implementations
{
    class ReadOperationStrategy : IReadOperationStrategy
    {
        private static readonly Dictionary<string, IReadFile> _readers;
        static ReadOperationStrategy()
        {
            _readers = new Dictionary<string, IReadFile>();
            _readers.Add(".txt", new ReadFromTxtFile());
        }

        public IReadFile GetReader(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            if(_readers.TryGetValue(extension, out IReadFile reader))
            {
                return reader;
            }
            return null;
        }
    }
}
