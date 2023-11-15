namespace CQRSDemo.Contracts.Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent()
        {
            EventId = Guid.NewGuid();
        }
        public Guid EventId { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
