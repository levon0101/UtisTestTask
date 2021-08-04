using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Grpc.Core;
using UtisTestTask.Model;
using UtisTestTask.ServiceContract;

namespace UtisTestTask.Client.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private WrokerIntegration.WrokerIntegrationClient _client;

        public WorkerRepository()
        {
            Channel channel = new Channel(Properties.Settings.Default.ApiHostAddress, ChannelCredentials.Insecure);
            _client = new WrokerIntegration.WrokerIntegrationClient(channel);
        }

        public async Task<IEnumerable<Worker>> AllWorkers()
        {
            var workers = new List<Worker>();
            try
            {
                using (var result = _client.GetWorkerStream(new EmptyMessage()))
                {
                    while (await result.ResponseStream.MoveNext())
                    {
                        var workerMsg = result.ResponseStream.Current;
                        workers.Add(new Worker
                        {
                            Id = workerMsg.Id,
                            Name = workerMsg.FirstName,
                            Surname = workerMsg.LastName,
                            Patronymic = workerMsg.MiddleName,
                            HaveChildren = workerMsg.HaveChildren,
                            Sex = (Model.Sex)(int)workerMsg.Sex,
                        });
                    }
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Service error: {ex.Message}");
                //TODO Log there  
            }

            return workers;
        }

        public async Task<bool> DeleteWorker(long workerId)
        {
            try
            {
                var result = await _client.DeleteWorkerByIdAsync(new WorkerIdMessage {Id = workerId});

                if (result != null)
                    return true;
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Service error: {ex.Message}");
                //TODO Log there  
            }

            return false;
        }

        public async Task<Worker> GetWorkerById(long workerId)
        {
            try
            {
                var result = await _client.GetWorkerByIdAsync(new WorkerIdMessage { Id = workerId });

                if (result.Id == 0)
                    return null;

                return new Worker
                {
                    Id = result.Id,
                    Name = result.FirstName,
                    Surname = result.LastName,
                    Patronymic = result.MiddleName,
                    HaveChildren = result.HaveChildren,
                    Sex = (Model.Sex)(int)result.Sex
                };
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Service error: {ex.Message}");
                //TODO Log there  
            }

            return null;
        }

        public async Task<Worker> AddOrUpdateWorker(Worker worker)
        {
            try
            {
                var workerMsg = new WrokerMessage
                {
                    Id = worker.Id,
                    FirstName = worker.Name ?? string.Empty,
                    LastName = worker.Surname ?? string.Empty,
                    MiddleName = worker.Patronymic ?? string.Empty,
                    HaveChildren = worker.HaveChildren,
                    Sex = (ServiceContract.Sex)(int)worker.Sex,
                };

                var result = await _client.AddOrUpdateWorkerAsync(workerMsg);

                if (result.Id == 0)
                    return null;

                return new Worker
                {
                    Id = result.Id,
                    Name = result.FirstName,
                    Surname = result.LastName,
                    Patronymic = result.MiddleName,
                    HaveChildren = result.HaveChildren,
                    Sex = (Model.Sex)(int)result.Sex
                };
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"Service error: {ex.Message}");
                //TODO Log there  
            }

            return null;
        }
    }
}
