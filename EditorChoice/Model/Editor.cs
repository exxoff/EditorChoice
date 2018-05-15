using Newtonsoft.Json;

namespace EditorChoice.Model
{
    public class Editor
    {
        [JsonProperty("name")]
        public string EditorName { get; set; }

        [JsonProperty("exe")]
        public string ExePath { get; set; }

        [JsonProperty("icon")]
        public string IconFilePath { get; set; }

        [JsonProperty("options")]
        public string Options { get; set; }

        [JsonProperty("shortcut")]
        public string ShortcutKey { get; set; }

    }
}
