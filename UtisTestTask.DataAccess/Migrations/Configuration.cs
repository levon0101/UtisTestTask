using UtisTestTask.Model;

namespace UtisTestTask.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UtisTestTask.DataAccess.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UtisTestTask.DataAccess.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Workers.AddOrUpdate(x => x.Id,
                new Worker { Id = 1, FirstName = "Levon", LastName = "Mardanyan", MiddleName = "Grigori", Birthday = 999, HaveChildren = true, Sex = Sex.Male },
                new Worker { Id = 2, FirstName = "Angella", LastName = "Tsoy", Birthday = 888, HaveChildren = true, Sex = Sex.Female }
            );
        }
    }
}
