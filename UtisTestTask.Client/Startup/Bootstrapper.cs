using Autofac; 
using Prism.Events;
using UtisTestTask.Client.View;
using UtisTestTask.Client.ViewModel;

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


            return builder.Build();
        }
    }
}
