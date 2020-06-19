using MicroRabbit.Domain.Core.Events;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Hanlde(TEvent @event);
    }

    public interface IEventHandler
    {

    }

}
