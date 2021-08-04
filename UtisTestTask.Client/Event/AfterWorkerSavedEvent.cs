using Prism.Events;
using UtisTestTask.Model;

namespace UtisTestTask.Client.Event
{
    public class AfterWorkerSavedEvent : PubSubEvent<AfterWorkerSavedEventArgs>
    {
    }

    public class AfterWorkerSavedEventArgs
    {
        public Worker Worker { get; set; }
    }
}
