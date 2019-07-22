using DataAnalyzer.Core;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModule.EventHandlers
{
    public class ListenToFileNameEvent
    {
        IEventAggregator eventAggregator;
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


        public ListenToFileNameEvent(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<LoadFileEvent>().Subscribe(ReadFileName);
        }

        public void ReadFileName(string fileName)
        {
            FileName = fileName;
        }


    }
}
