using EditorChoice.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorChoice.ViewModel
{
    class SettingsViewModel:ViewModelBase
    {
        public List<Editor> Editors { get; set; }

        public string ExePath { get; set; }

        public string IconFilePath { get; set; }

        public string EditorName { get; set; }

        public string Options { get; set; }

        public RelayCommand SaveCommand { get; set; }




    }
}
