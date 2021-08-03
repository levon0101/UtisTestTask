using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using UtisTestTask.Model;

namespace UtisTestTask.Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _test;

        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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


        private void OnDeleteCommandExecute(Worker obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnEditCommandExecute(Worker obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnAddCommandExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}
