using MongoDB.Driver;

namespace DataLayer
{
    public class MongoDbContext
    {
        public MongoClient _client;

        public IMongoDatabase _database;

        public MongoDbContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");

            _database = _client.GetDatabase("Biodigestor");
        }
    }
}
