using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using UtisTestTask.Service.Services;
using UtisTestTask.ServiceContract;

namespace UtisTestTask.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 5555;
            Server server = new Server
            {
                Services = { WrokerIntegration.BindService(new WorkerService()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"Worker Server Listening on port {port}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
