using System.Threading.Tasks;
using Grpc.Core;
using UtisTestTask.Model;
using UtisTestTask.Service.Repositories;
using UtisTestTask.ServiceContract;
using Sex = UtisTestTask.ServiceContract.Sex;

namespace UtisTestTask.Service.Services
{
    public class WorkerService : WrokerIntegration.WrokerIntegrationBase
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public override async Task GetWorkerStream(EmptyMessage request, IServerStreamWriter<WrokerMessage> responseStream, ServerCallContext context)
        {
            var workersFromDb = await _workerRepository.GetAllAsync();

            foreach (var worker in workersFromDb)
            {
                var workerMessage = new WrokerMessage
                {
                    Id = worker.Id,
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    MiddleName = worker.MiddleName,
                    Birthday = worker.Birthday,
                    Sex = (UtisTestTask.ServiceContract.Sex)(int)worker.Sex,
                };

                await responseStream.WriteAsync(workerMessage);
            }
        }

        public override async Task<WrokerMessage> GetWorkerById(WorkerIdMessage request, ServerCallContext context)
        {
            var workersFromDb = await _workerRepository.GetByIdAsync(request.Id);

            if (workersFromDb == null) return null;

            return new WrokerMessage
            {
                Id = workersFromDb.Id,
                FirstName = workersFromDb.FirstName,
                LastName = workersFromDb.LastName,
                MiddleName = workersFromDb.MiddleName,
                Birthday = workersFromDb.Birthday,
                Sex = (UtisTestTask.ServiceContract.Sex)(int)workersFromDb.Sex,
            };
        }

        public override async Task<WrokerMessage> AddOrUpdateWorker(WrokerMessage request, ServerCallContext context)
        {
            var workerFromDb = await _workerRepository.GetByIdAsync(request.Id);

            if (workerFromDb == null)
            {
                _workerRepository.Add(new Worker
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Birthday = request.Birthday,
                    HaveChildren = request.HaveChildren,
                    Sex = (Model.Sex)(int)request.Sex,
                });
            }
            else
            {
                workerFromDb.FirstName = request.FirstName;
                workerFromDb.LastName = request.LastName;
                workerFromDb.MiddleName = request.MiddleName;
                workerFromDb.Birthday = request.Birthday;
                workerFromDb.HaveChildren = request.HaveChildren;
                workerFromDb.Sex = (Model.Sex)(int)request.Sex;
            }

            await _workerRepository.SaveAsync();

            return request;
        }

        public override async Task<WrokerMessage> DeleteWorkerById(WorkerIdMessage request, ServerCallContext context)
        {
            await _workerRepository.DeleteByWorkerId(request.Id);
            await _workerRepository.SaveAsync();

            return null;
        }
    }
}
