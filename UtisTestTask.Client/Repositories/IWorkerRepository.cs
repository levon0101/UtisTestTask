using System.Collections.Generic;
using System.Threading.Tasks;
using UtisTestTask.Model;

namespace UtisTestTask.Client.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> AllWorkers();

        Task<bool> DeleteWorker(long workerId);

        Task<Worker> GetWorkerById(long workerId);

        Task<Worker> AddOrUpdateWorker(Worker worker);
    }
}