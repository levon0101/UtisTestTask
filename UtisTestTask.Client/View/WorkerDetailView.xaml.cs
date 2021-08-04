using System.Windows;
using UtisTestTask.Client.ViewModel;

namespace UtisTestTask.Client.View
{
    /// <summary>
    /// Interaction logic for WorkerDetailView.xaml
    /// </summary>
    public partial class WorkerDetailView : Window, ICloseable
    {
        private readonly WorkerDetailViewModel _viewModel;

        public WorkerDetailView(WorkerDetailViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            DataContext = viewModel;
            Loaded += OnWindowLoadedEventExecute;
        }

        private async void OnWindowLoadedEventExecute(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
