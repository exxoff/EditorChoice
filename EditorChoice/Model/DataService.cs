using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Editors = ReadSource(currentDirectory + "\\editors.json", Path.GetExtension(Document.Instance.DucumentPath).Trim('.'));



            callback(Editors, null);
        }


        private List<Editor> ReadSource(string Jsonfile)
        {
            List<Editor> retList = new List<Editor>();

            using (StreamReader reader = new StreamReader(new Uri(Jsonfile).AbsolutePath))
            {
                var json = reader.ReadToEnd();

                retList = JsonConvert.DeserializeObject<List<Editor>>(json);
            }


            return retList;
        }

        private List<Editor> ReadSource(string Jsonfile, string extension)
        {
            List<Editor> retList = new List<Editor>();

            using (StreamReader reader = new StreamReader(new Uri(Jsonfile).AbsolutePath))
            {
                var json = reader.ReadToEnd();

                retList = JsonConvert.DeserializeObject<List<Editor>>(json);
            }

            var list = retList.Where(x => (x.Extensions != null) && x.Extensions.Contains(extension)).ToList();

            return list;
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