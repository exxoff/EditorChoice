using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EditorChoice.Model
{
    public class DataService : IDataService
    {

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



        public void GetData(Action<List<Editor>, Exception> callback)
        {
            // Use this to connect to the actual data service
            Editors = new List<Editor>();

            Editors = ReadSource("editors.json");
            //Editors.Add(new Editor()
            //{
            //    EditorName = "Notepad",
            //    ExePath = @"C:\Windows\System32\Notepad.exe",
            //    IconFile = @"c:\Users\v063992\Downloads\icon1.png"
            //});

            //Editors.Add(new Editor()
            //{
            //    EditorName = "Notepad++",
            //    ExePath = @"c:\PFiles\PortableApps\PortableApps\Notepad++Portable\Notepad++Portable.exe",
            //    IconFile = @"c:\PFiles\PortableApps\PortableApps\Notepad++Portable\App\AppInfo\appicon.ico"
            //});


            callback(Editors, null);
        }


        private List<Editor> ReadSource(string Jsonfile)
        {
            List<Editor> retList = new List<Editor>();

            using (StreamReader reader = new StreamReader(Jsonfile))
            {
                var json = reader.ReadToEnd();

                retList = JsonConvert.DeserializeObject<List<Editor>>(json);
            }


                return retList;
        }
        public DataService()
        {
            //var item = new Editor()
            //{
            //    EditorName = "Notepad",
            //    ExePath = @"C:\Windows\System32\Notepad.exe",
            //    IconFile = @"c:\Users\v063992\Downloads\icon1.png"
            //};

            //Editors.Add(item);
        }
    }
}