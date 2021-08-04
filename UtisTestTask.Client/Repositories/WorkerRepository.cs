using System;
using System.Collections.Generic;
using System.Threading;
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
    }
}
