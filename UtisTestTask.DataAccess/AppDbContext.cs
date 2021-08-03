using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UtisTestTask.Model;

namespace UtisTestTask.DataAccess
{
    public class SampleContextFactory : IDbContextFactory<AppDbContext>
    {
        private string connectionString = "Data Source=.\\sqlexpress; Initial Catalog=UtisTestTaskDb; Integrated Security=True";

        public AppDbContext Create()
        {
            return new AppDbContext(connectionString);
        }
    }
    public class AppDbContext : DbContext
    {

        public AppDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Worker> Workers { get; set; }
    }
}
