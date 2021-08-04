using System.Windows;
using UtisTestTask.Client.ViewModel;

namespace UtisTestTask.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel dataContext)
        {
            InitializeComponent();
            _mainViewModel = dataContext;
            DataContext = _mainViewModel;
            Loaded += MainWindowLoadedExecute;

        }

        private async void MainWindowLoadedExecute(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.LoadAsync();
        }
    }
}
