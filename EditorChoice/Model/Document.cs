namespace EditorChoice.Model
{
    public sealed class Document
    {
        static readonly Document instance = new Document();

        public string DucumentPath { get; set; }
        public static Document Instance
        {
            get { return instance; }

        }

    }
}
