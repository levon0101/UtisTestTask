using System.Collections.Generic;
using System.Threading.Tasks;

namespace UtisTestTask.Service.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        void Add(TEntity model);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        bool HasChanges();
        void Remove(TEntity model);
        Task SaveAsync();
    }
}