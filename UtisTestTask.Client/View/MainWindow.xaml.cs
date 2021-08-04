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
            Loaded += MainWIndowLoadedExecute;

        }

        private void MainWIndowLoadedExecute(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Load();
        }
    }
}
