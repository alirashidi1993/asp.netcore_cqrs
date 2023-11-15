using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.Context.Models
{
    public class Movie
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long BoxOffice { get; set; }
        public bool IsAdultMovie { get; set; }
       
    }
}
