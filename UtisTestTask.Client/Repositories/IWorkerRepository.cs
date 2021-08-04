using System.Collections.Generic;
using System.Threading.Tasks;
using UtisTestTask.Model;

namespace UtisTestTask.Client.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> AllWorkers();
    }
}