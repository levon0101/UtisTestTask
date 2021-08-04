using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Grpc.Core;
using Prism.Events;
using UtisTestTask.Client.Repositories;
using UtisTestTask.Client.View;
using UtisTestTask.Client.ViewModel;
using UtisTestTask.ServiceContract;

namespace UtisTestTask.Client.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<WorkerRepository>().As<IWorkerRepository>();
             

            return builder.Build();
        }
    }
}
