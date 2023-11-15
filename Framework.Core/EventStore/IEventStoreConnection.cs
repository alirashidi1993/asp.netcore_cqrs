using CQRSDemo.Contracts.Events;

namespace Framework.Core.EventStore
{
    public interface IEventStoreConnection
    {
        Task AppendToStreamAsync<T>(T @event) where T:BaseEvent;
    }
}
