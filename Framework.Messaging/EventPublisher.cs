using CQRSDemo.Contracts.Events;
using Framework.Core.Messaging;
using MassTransit;

namespace Framework.Messaging
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint publishEndpoint;

        public EventPublisher(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }
        public async void Publish<T>(T meseage) where T : BaseEvent
        {
            await publishEndpoint.Publish(meseage);
        }
    }
}