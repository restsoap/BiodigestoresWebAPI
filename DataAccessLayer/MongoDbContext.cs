using MongoDB.Driver;

namespace DataAccessLayer
{
    public class MongoDbContext
    {
        private readonly MongoClient _client;

        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");

            _database = _client.GetDatabase("Biodigestor");
        }
        
    }
}
