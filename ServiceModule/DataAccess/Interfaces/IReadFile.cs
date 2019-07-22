using ServiceModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModule.DataAccess.Interfaces
{
    interface IReadFile
    {
        List<Message> ReadData(string fileName);
    }
}
