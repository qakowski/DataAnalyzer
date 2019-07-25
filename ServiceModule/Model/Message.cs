using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModule.Model
{
    public class Message 
    {
        private int messageId;

        public int MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }

        private string messageContent;

        public string MessageContent
        {
            get { return messageContent; }
            set { messageContent = value; }
        }


    }
}
