using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Read.Context.Models;

namespace Read.Context
{
    public class ReadDbContext:MongoClient
    {
        private readonly string dbName = "CQRSDemo";
        public ReadDbContext(string connectionString):base(connectionString)
        {
        }

        public IMongoCollection<Movie> Movies => GetDatabase(dbName).GetCollection<Movie>("Movies");
        
    }
}
