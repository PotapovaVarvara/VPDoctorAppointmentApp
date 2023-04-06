using MongoDB.Driver;

namespace Repository.Infrastructure;

public class MongoDbClient
{
    public MongoClient Client = new MongoClient("mongodb://localhost:27017");
 
}