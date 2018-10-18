using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

namespace EditorChoice.Model
{
    public class Editor
    {
        [JsonProperty("name")]
        public string EditorName { get; set; }


        private string exePath;

        [JsonProperty("exe")]
        public string ExePath
        {
            get { return exePath; }
            set
            {
                exePath = value;
                if (File.Exists(value))
                {
                    if (string.IsNullOrEmpty(IconFilePath))
                    {
                        IconImage = Icon.ExtractAssociatedIcon(value)?.ToBitmap().ToBitmapImage();
                    }

                }
            }
        }

        private string iconFilePath;

        [JsonProperty("icon")]
        public string IconFilePath
        {
            get { return iconFilePath; }
            set
            {
                iconFilePath = value;
                if (IconImage == null)
                {
                    IconImage = new Bitmap(value).ToBitmapImage();
                }
            }
        }


        
        //public string IconFilePath { get; set; }

        public BitmapImage IconImage { get; set; }

        [JsonProperty("options")]
        public string Options { get; set; }

        [JsonProperty("shortcut")]
        public string ShortcutKey { get; set; }

        [JsonProperty("extensions")]
        public List<string> Extensions { get; set; }
    }
}
