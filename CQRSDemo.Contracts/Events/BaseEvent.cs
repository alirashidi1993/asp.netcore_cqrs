using Newtonsoft.Json;

namespace CQRSDemo.Contracts.Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent(string eventType)
        {
            Timestamp = DateTime.Now;
            EventType = eventType;
            EventData = SerializeEventData();
        }

        public string EventType { get; }
        public string EventData { get; }
        public DateTime Timestamp { get; }
        protected abstract object BuildEventData();

        private string SerializeEventData()
        {
            var dataForSerialization = BuildEventData();
            return JsonConvert.SerializeObject(dataForSerialization, DefaultJsonSerializerSettings);
        }
        protected static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };
    }

}
