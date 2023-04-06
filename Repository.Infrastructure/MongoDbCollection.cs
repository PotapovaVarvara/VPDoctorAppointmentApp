using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository.Infrastructure;

public class MongoDbCollection<T>
{
    public IMongoCollection<T> Collection { get; private set; }

    public MongoDbCollection(MongoDbClient client, IDatabaseNameProvider databaseNameProvider)
    {
        var db = client.Client.GetDatabase(databaseNameProvider.Get());
        
        Collection = db.GetCollection<T>(nameof(T));
    }
}