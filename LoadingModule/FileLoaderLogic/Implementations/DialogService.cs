using LoadingModule.FileLoaderLogic.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingModule.FileLoaderLogic.Implementations
{
    class DialogService : IDialogService
    {
        public string OpenFile()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Txt files (*.txt)|*.txt",
                DefaultExt = "*.txt"
            };

            bool? result = dialog.ShowDialog();

            return result == true ? dialog.FileName : null;

           
        }
    }
}
