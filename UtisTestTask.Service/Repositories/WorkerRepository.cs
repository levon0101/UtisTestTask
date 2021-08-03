using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UtisTestTask.DataAccess;
using UtisTestTask.Model;

namespace UtisTestTask.Service.Repositories
{
    public class WorkerRepository : GenericRepository<Worker, AppDbContext> , IWorkerRepository
    {
        public WorkerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Worker>> GetAllAsync()
        {
            return await Context.Workers.Where(w => !w.IsDeleted).ToListAsync();
        }

        public override async Task<Worker> GetByIdAsync(long id)
        {
            return await Context.Workers.Where(w => !w.IsDeleted).FirstOrDefaultAsync(w => w.Id == id);
        }
        
        public async Task DeleteByWorkerId(long workerId)
        {

            var workerFromDb = await GetByIdAsync(workerId);

            if (workerFromDb == null)
                return;

            workerFromDb.IsDeleted = true;
        }
    }
}
