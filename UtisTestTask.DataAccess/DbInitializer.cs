using System.Collections.Generic;
using System.Data.Entity;
using UtisTestTask.Model;

namespace UtisTestTask.DataAccess
{
    public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            IList<Worker> defaultWorkers = new List<Worker>();

            defaultWorkers.Add(new Worker { Id = 1, FirstName = "Levon", LastName = "Mardanyan", MiddleName = "Grigori", Birthday = 999, HaveChildren = true, Sex = Sex.Male });
            defaultWorkers.Add(new Worker { Id = 1, FirstName = "Angella", LastName = "Tsoy", Birthday = 888, HaveChildren = true, Sex = Sex.Female });

            context.Workers.AddRange(defaultWorkers);

            base.Seed(context);
        }
    }
}