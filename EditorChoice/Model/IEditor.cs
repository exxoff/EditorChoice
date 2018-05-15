namespace EditorChoice.Model
{
    public interface IEditor
    {
        string EditorName { get; set; }
        string ExePath { get; set; }
        string IconFile { get; set; }
    }
}