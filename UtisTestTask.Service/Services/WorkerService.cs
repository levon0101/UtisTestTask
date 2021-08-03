using System.Threading.Tasks;
using Grpc.Core;
using UtisTestTask.ServiceContract;

namespace UtisTestTask.Service.Services
{
    internal class WorkerService : WrokerIntegration.WrokerIntegrationBase
    {
        public override Task GetWorkerStream(EmptyMessage request, IServerStreamWriter<WrokerMessage> responseStream, ServerCallContext context)
        {
            return base.GetWorkerStream(request, responseStream, context);
        }

        public override Task<WrokerMessage> GetWorkerById(WorkerIdMessage request, ServerCallContext context)
        {
            return base.GetWorkerById(request, context);
        }

        public override Task<WrokerMessage> AddOrUpdateWorker(WrokerMessage request, ServerCallContext context)
        {
            return base.AddOrUpdateWorker(request, context);
        }

        public override Task<WrokerMessage> DeleteWorkerById(WorkerIdMessage request, ServerCallContext context)
        {
            return base.DeleteWorkerById(request, context);
        }
    }
}
