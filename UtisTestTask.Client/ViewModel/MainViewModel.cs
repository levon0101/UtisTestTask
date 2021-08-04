using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Grpc.Core;
using Prism.Commands;
using Prism.Events;
using UtisTestTask.Client.Repositories;
using UtisTestTask.Model;
using UtisTestTask.ServiceContract;

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
        }

        #region Properties
        
        #region Commands

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        #endregion End Commands

        public ObservableCollection<Worker> Workers { get; set; }

        #endregion End Properties

        public async void Load()
        {
           var workersFromServer =  await _workerRepository.AllWorkers();
           Workers.Clear();

           foreach (var worker in workersFromServer)
           {
               Workers.Add(worker);
           }
        }

        private void OnDeleteCommandExecute(Worker worker)
        {
            throw new System.NotImplementedException();
        }

        private void OnEditCommandExecute(Worker worker)
        {
            throw new System.NotImplementedException();
        }

        private void OnAddCommandExecute()
        {

            //Channel channel = new Channel("127.0.0.1:5555", ChannelCredentials.Insecure);
            //var client = new WrokerIntegration.WrokerIntegrationClient(channel);
            ////var replay = client.AddOrUpdateWorker(new WrokerMessage(){FirstName = "Levon"});
            //var replay = client.GetWorkerById(new WorkerIdMessage{Id = 1});
            //MessageBox.Show($"{replay.FirstName}");

            //channel.ShutdownAsync().Wait();
            //MessageBox.Show("End");
        }
    }
}
