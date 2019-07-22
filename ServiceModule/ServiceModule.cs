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

namespace ServiceModule
{
    public class ServiceModule : IModule
    {
        private IEventAggregator eventAggregator;
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value;
            }
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var register = containerProvider.Resolve<IModuleManager>();
            register.LoadModule("ServiceModule");
            ListenToEvent(eventAggregator);
            

        }
        public void ListenToEvent(IEventAggregator eventAggregator)
        {
            var eventHandler = new EventHandlers.ListenToFileNameEvent(eventAggregator);
            FileName = eventHandler.FileName;

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IReadFile, ReadFromTxtFile>();
        }
    }
}
