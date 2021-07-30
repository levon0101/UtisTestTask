using System.Windows;
using System.Windows.Threading;
using Autofac;
using UtisTestTask.Client.Startup;
using UtisTestTask.Client.View;

namespace UtisTestTask.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>  
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var butstrapper = new Bootstrapper();
            var container = butstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

            MessageBox.Show($"Exception occur: {e.Exception.Message}");
            e.Handled = true;
        }
    }
}
