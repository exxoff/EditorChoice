using EditorChoice.ViewModel;
using System.Windows;

namespace EditorChoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {

            //using (StreamReader sr = new StreamReader("editors.json"))
            //{
            //    List<IEditor> editors = JsonConvert.DeserializeObject<List<IEditor>>(sr.ReadToEnd());
            //}

            InitializeComponent();


            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}