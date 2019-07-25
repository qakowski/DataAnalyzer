using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Unity;
using System.ComponentModel;
using Prism.Events;
using ServiceModule;
using DataAnalyzer.Core;

namespace DataAnalyzer.ViewModels
{
    class MainWindowViewModel : BindableBase
    {


        public IEventAggregator eventAggregator;
        ServiceModule.ServiceModule serviceModule;
        public MainWindowViewModel(ServiceModule.ServiceModule serviceModule, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.serviceModule = serviceModule;

            eventAggregator.GetEvent<LoadFileEvent>().Subscribe(ListenToEvent);
        }


        public void ListenToEvent(string message)
        {
            serviceModule.ListenToEvent(eventAggregator);
        }






    }
}
