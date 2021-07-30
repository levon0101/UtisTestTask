using System.Windows;
using UtisTestTask.Client.ViewModel;

namespace UtisTestTask.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
