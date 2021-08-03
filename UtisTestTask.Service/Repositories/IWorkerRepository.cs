using System.Threading.Tasks;
using UtisTestTask.Model;

namespace UtisTestTask.Service.Repositories
{
    public interface IWorkerRepository : IGenericRepository<Worker>
    {
        Task<Worker> AddOrUpdateWorker(Worker worker);

        Task DeleteByWorkerId(long workerId);
    }
}