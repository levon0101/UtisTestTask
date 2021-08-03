using Autofac;
using UtisTestTask.DataAccess;
using UtisTestTask.Service.Repositories;
using UtisTestTask.Service.Services;

namespace UtisTestTask.Service.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AppDbContext>()
                    .AsSelf()
                    .WithParameter("connectionString", Properties.Settings.Default.ConnectionString)
                    .SingleInstance();

            builder.RegisterType<WorkerRepository>().As<IWorkerRepository>();

            builder.RegisterType<WorkerService>().AsSelf();

            return builder.Build();
        }
    }
}
