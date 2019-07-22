using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadingModule.FileLoaderLogic.Implementations;
using LoadingModule.FileLoaderLogic.Interfaces;
namespace LoadingModule
{
    public class LoadingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var register = containerProvider.Resolve<IRegionManager>();
            register.RegisterViewWithRegion("FileRegion", typeof(Views.FileLoader));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogService, DialogService>();
        }
    }
}
