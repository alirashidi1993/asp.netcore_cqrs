using CQRSDemo.Contracts.Events;
using EventStore.Client;
using Framework.Core.EventStore;
using System.Text.Json;

namespace Read.EventStore
{
    public class EventStoreConnection : IEventStoreConnection
    {
        private readonly EventStoreClient eventStoreClient;

        public EventStoreConnection(EventStoreClient eventStoreClient)
        {
            this.eventStoreClient = eventStoreClient;
        }
        public async Task AppendToStreamAsync<T>(T @event) where T : BaseEvent
        {
            var eventData = new EventData(
                Uuid.NewUuid(),
                @event.EventType,
                JsonSerializer.SerializeToUtf8Bytes(@event.EventData));

            await eventStoreClient.AppendToStreamAsync(@event.EventType, StreamState.Any, new[] { eventData });
        }
    }
}
