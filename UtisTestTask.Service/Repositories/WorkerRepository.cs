using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UtisTestTask.DataAccess;
using UtisTestTask.Model;

namespace UtisTestTask.Service.Repositories
{
    public class WorkerRepository : GenericRepository<Worker, AppDbContext>
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

        public async Task<Worker> AddOrUpdateWorker(Worker worker)
        {
            if (worker.Id == 0)
            {
                Add(worker);
            }
            else
            {
                var workerFromDb = await GetByIdAsync(worker.Id);

                if (workerFromDb == null)
                    return null;

                workerFromDb.FirstName = worker.FirstName;
                workerFromDb.LastName = worker.LastName;
                workerFromDb.MiddleName = worker.MiddleName;
                workerFromDb.Birthday = worker.Birthday;
                workerFromDb.HaveChildren = worker.HaveChildren;
                workerFromDb.Sex = worker.Sex;
            }

            //await SaveAsync();

            return worker;
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
