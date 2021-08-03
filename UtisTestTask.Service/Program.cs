using System;
using Autofac;
using Grpc.Core;
using UtisTestTask.DataAccess;
using UtisTestTask.Service.Repositories;
using UtisTestTask.Service.Services;
using UtisTestTask.Service.Startup;
using UtisTestTask.ServiceContract;

namespace UtisTestTask.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Bootstrapper().Bootstrap();
            var db = container.Resolve<AppDbContext>();
            db.Database.CreateIfNotExists();

            var workerService = container.Resolve<WorkerService>(); 

            Server server = new Server
            {
                Services = { WrokerIntegration.BindService(workerService)},
                Ports = { new ServerPort("localhost", Properties.Settings.Default.PortNumber, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"Worker Server Listening on port {Properties.Settings.Default.PortNumber}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
