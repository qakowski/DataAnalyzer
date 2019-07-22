using ServiceModule.DataAccess.Interfaces;
using ServiceModule.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModule.DataAccess.Implementations
{
    class ReadFromTxtFile : IReadFile
    {
        public List<Message> ReadData(string fileName)
        {
            List<Message> messages = new List<Message>();
            string[] oneLineSeperated;
            string[] allLines = File.ReadAllLines(fileName);

            
            foreach (var line in allLines)
            {
                oneLineSeperated = line.Split(';');

                foreach (var nestedLine in oneLineSeperated)
                {
                    var tempMessage = new Message
                    {
                        MessageId = int.Parse(nestedLine[0].ToString()),
                        MessageContent = nestedLine[1].ToString()
                    };
                    messages.Add(tempMessage);
                }
            }


            return messages;
        }
    }
}
