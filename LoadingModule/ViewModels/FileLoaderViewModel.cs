using DataAnalyzer.Core;
using LoadingModule.FileLoaderLogic.Implementations;
using LoadingModule.FileLoaderLogic.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingModule.ViewModels
{
    class FileLoaderViewModel : BindableBase
    {
        public DelegateCommand LoadFileCommand { get; set; }
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                SetProperty(ref fileName, value);
            }
        }



        public FileLoaderViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            LoadFileCommand = new DelegateCommand(LoadFile);

        }

        private void LoadFile()
        {
            FileName = OpenFIle.ReadFileName(_dialogService);
            _eventAggregator.GetEvent<LoadFileEvent>().Publish(FileName);
        }

    }
}
