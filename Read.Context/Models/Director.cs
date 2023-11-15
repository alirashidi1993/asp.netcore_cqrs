using MongoDB.Bson.Serialization.Attributes;

namespace Read.Context.Models
{
    public class Director
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
