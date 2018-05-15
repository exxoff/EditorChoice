using EditorChoice.Model;
using EditorChoice.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace EditorChoice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Document d = Document.Instance;
            d.DucumentPath = e.Args[0];
            //ComposeObjects();

            //MainWindow.Show();

        }

        private void ComposeObjects()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDataService, DataService>();


            SimpleIoc.Default.Register<MainViewModel>();
            //MainViewModel viewModel = new MainViewModel(ServiceLocator.Current.GetInstance<IDataService>());
            //MainWindow = new MainWindow(viewModel);

            //MainWindow = new MainWindow(viewModel);
        }


    }
}
