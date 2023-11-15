using CQRSDemo.Contracts.Events;

namespace Framework.Core.Messaging
{
    public interface IEventPublisher
    {
        public void Publish<T>(T meseage) where T : BaseEvent;
    }
}
