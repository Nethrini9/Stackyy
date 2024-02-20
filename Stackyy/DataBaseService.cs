using MongoDB.Driver;

namespace Stackyy
{
    public class DataBaseService
    {
        private readonly IMongoDatabase _database;  
        public DataBaseService() 
        {
            var client= new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("Nethrini");
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
