using EditorChoice.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EditorChoice.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public const string EditorsPropertyName = "Editors";
        public const string IsEnabledPropertyName = "IsEnabled";

        public bool IsEnabled { get; set; }

        private List<Editor> editors;

        public List<Editor> Editors
        {
            get { return editors; }
            set
            {
                if (editors == null)
                {
                    editors = new List<Editor>();
                }
                editors = value;
            }
        }

        public string DocumentPath { get; set; }

        public RelayCommand<object> DoStart
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {

            Document d = Document.Instance;

            this.DocumentPath = d.DucumentPath;
            DoStart = new RelayCommand<object>(p => StartEditor(p));

            dataService.GetData((items, error) =>
            {
                if (error != null)
                {
                    throw new System.Exception();
                }
                Editors = items;

            });

            

        }

        public void StartEditor(object obj)
        {
            if (obj.GetType() != typeof(Editor))
            {
                MessageBox.Show("Wrong Type!");
            }
            else
            {
                var editor = obj as Editor;

                ProcessStartInfo processStartInfo = new ProcessStartInfo();

                processStartInfo.Arguments = string.Format("{0} {1}", this.DocumentPath, editor.Options);
                processStartInfo.FileName = editor.ExePath;
                Process.Start(processStartInfo);
                Application.Current.Shutdown();
                
            }


            
        }





        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}