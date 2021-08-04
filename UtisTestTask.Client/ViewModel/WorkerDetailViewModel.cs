using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using UtisTestTask.Client.Event;
using UtisTestTask.Client.Repositories;
using UtisTestTask.Model;

namespace UtisTestTask.Client.ViewModel
{
    public class WorkerDetailViewModel : ViewModelBase
    {
        private readonly long? _workerId;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWorkerRepository _workerRepository;
        private Worker _worker;

        public WorkerDetailViewModel(long? workerId, IEventAggregator eventAggregator,
            IWorkerRepository workerRepository)
        {
            _workerId = workerId;
            _eventAggregator = eventAggregator;
            _workerRepository = workerRepository;

            SaveCommand = new DelegateCommand<ICloseable>(OnSaveCommandExecute);
            CancelCommand = new DelegateCommand<ICloseable>(OnCancelCommandExecute);
        }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public Worker Worker
        {
            get => _worker;
            set
            {
                _worker = value;
                OnPropertyChanged();
            }
        }

        public int SexIndex
        {
            get => (int)Worker.Sex;
            set
            {
                Worker.Sex = (Model.Sex)value;
                OnPropertyChanged();
            }
        }

        public async Task LoadAsync()
        {
            if (_workerId == null)
            {
                Worker = new Worker();
            }
            else
            {
                Worker = await _workerRepository.GetWorkerById(_workerId.Value);
            }

            SexIndex = (int)Worker.Sex;
        }

        private void OnCancelCommandExecute(ICloseable window)
        {
            window.Close();
        }

        private async void OnSaveCommandExecute(ICloseable window)
        {
             await _workerRepository.AddOrUpdateWorker(Worker);

            _eventAggregator.GetEvent<AfterWorkerSavedEvent>().Publish(new AfterWorkerSavedEventArgs
            {
                Worker = Worker
            });

            window.Close();
        }
    }
}
