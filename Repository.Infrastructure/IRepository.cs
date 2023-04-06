
using MongoDB.Driver;

namespace Repository.Infrastructure;

public interface IRepository<T> where T: class
{
    Task<T> FindByIdAsync(Guid id);
    
    Task<T> FindByTelegramIdAsync(long telegramId);
    
    Task AddOneAsync(T entity);
}

public class Repository<T>:  MongoDbCollection<T>, IRepository<T> where T: class
{
    private static readonly MongoDbClient client = new MongoDbClient();
    
    public Repository(IDatabaseNameProvider databaseNameProvider): base(client, databaseNameProvider)
    {
        
    }
    
    public async Task<T> FindByIdAsync(Guid id)
    {
        //var collection = db.GetCollection<BsonDocument>("users");
        var filter = Builders<T>.Filter.Eq("_id", id);
        
        var document = await Collection.FindAsync(filter);

        return document.FirstOrDefault();
    }

    public async Task<T> FindByTelegramIdAsync(long telegramId)
    {
        var filter = Builders<T>.Filter.Eq("telegramId", telegramId);
        
        var document = await Collection.FindAsync(filter);

        return document.FirstOrDefault();
    }

    public async Task AddOneAsync(T entity)
    {
        await Collection.InsertOneAsync(entity);
    }
}