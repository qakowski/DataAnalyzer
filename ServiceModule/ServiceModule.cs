using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModule.DataAccess.Implementations;
using ServiceModule.DataAccess.Interfaces;
using Prism.Events;
using DataAnalyzer.Core;
using ServiceModule.Model;
using System.IO;

namespace ServiceModule
{
    public class ServiceModule : IModule
    {
        //private IEventAggregator eventAggregator;
        private string fileName;
        private IReadOperationStrategy readOperationStrategy;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        public ServiceModule()
        {

        }

        ServiceModule(IReadOperationStrategy readOperationStrategy)
        {
            this.readOperationStrategy = readOperationStrategy;
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
            var register = containerProvider.Resolve<IModuleManager>();
            register.LoadModule("ServiceModule");
        }

        public void ListenToEvent(IEventAggregator eventAggregator)
        {
            var eventHandler = new EventHandlers.ListenToFileNameEvent(eventAggregator);
            try
            {
                
                FileName = eventHandler.FileName;
                List<Message> messages = readOperationStrategy.GetReader(FileName).ReadData(FileName);
            }
            catch (Exception exception)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "log.txt", true))
                {
                    file.WriteLine(exception.Message);
                    file.Close();
                }
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IReadFile, ReadFromTxtFile>();
        }
    }
}
