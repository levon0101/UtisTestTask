using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using UtisTestTask.Client.Event;
using UtisTestTask.Client.Repositories;
using UtisTestTask.Client.View;
using UtisTestTask.Model;

namespace UtisTestTask.Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWorkerRepository _workerRepository;

        public MainViewModel(IEventAggregator eventAggregator, IWorkerRepository workerRepository)
        {
            _eventAggregator = eventAggregator;
            _workerRepository = workerRepository;

            AddCommand = new DelegateCommand(OnAddCommandExecute);
            EditCommand = new DelegateCommand<Worker>(OnEditCommandExecute);
            DeleteCommand = new DelegateCommand<Worker>(OnDeleteCommandExecute);

            Workers = new ObservableCollection<Worker>();

            _eventAggregator.GetEvent<AfterWorkerSavedEvent>().Subscribe(OnAfterWorkerSavedEventExecute);
        }

        #region Properties

        #region Commands

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        #endregion End Commands

        public ObservableCollection<Worker> Workers { get; set; }

        #endregion End Properties

        public async Task LoadAsync()
        {
            await UpdateWorkersList();
        }

        private async void OnDeleteCommandExecute(Worker worker)
        {
            var deleted = await _workerRepository.DeleteWorker(worker.Id);

            if (deleted)
            {
                MessageBox.Show($"Worker: {worker.Name} successfully deleted.");
                Workers.Remove(worker);
            }
        }

        private void OnEditCommandExecute(Worker worker)
        {
            ShowDetail(worker.Id);
        }

        private void OnAddCommandExecute()
        {
            ShowDetail(null);
        }

        private void ShowDetail(long? workerId)
        {
            if (WindowOperations.IsWindowOpen<WorkerDetailView>())
            {
                WindowOperations.BringTop<WorkerDetailView>();
                return;
            }

            var detailView = new WorkerDetailView(new WorkerDetailViewModel(workerId, _eventAggregator, _workerRepository))
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Topmost = true
            };

            detailView.Topmost = false;

            detailView.ShowDialog();
        }

        private async void OnAfterWorkerSavedEventExecute(AfterWorkerSavedEventArgs obj)
        {
            await UpdateWorkersList();
        }

        private async Task UpdateWorkersList()
        {
            var workersFromServer = await _workerRepository.AllWorkers();
            Workers.Clear();

            foreach (var worker in workersFromServer)
            {
                Workers.Add(worker);
            }
        }
    }
}
