using LoadingModule.FileLoaderLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingModule.FileLoaderLogic.Implementations
{
    public class OpenFIle
    {
        public static string ReadFileName(IDialogService _dialogService)
        {
            var fileName = _dialogService.OpenFile();
            if (fileName != null)
            {
                return fileName; 
            }
            else
            {
                return null;
            }
        }
}
}
