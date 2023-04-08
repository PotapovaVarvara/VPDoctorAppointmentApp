using MongoDB.Bson;
using MongoDB.Driver;
using Repository.Infrastructure.Models;

namespace Repository.Infrastructure;

public class MongoDbCollection<T>
{
    public IMongoCollection<T> Collection { get; private set; }

    public MongoDbCollection(MongoDbClient client, IDatabaseNameProvider databaseNameProvider, Client vpClient)
    {
        var db = client.Client.GetDatabase(databaseNameProvider.Get(vpClient.Id));
        
        Collection = db.GetCollection<T>(typeof(T).Name);
    }
}