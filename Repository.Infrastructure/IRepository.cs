
using MongoDB.Driver;
using Repository.Infrastructure.Models;

namespace Repository.Infrastructure;

public interface IRepository<T> where T: class
{
    Task<T> FindByIdAsync(Guid id);
    
    Task<T> FindByTelegramIdAsync(long telegramId);
    
    Task AddOneAsync(T entity);
    
    Task<List<T>> GetAll();
}

public class Repository<T>:  MongoDbCollection<T>, IRepository<T> where T: class
{
    private static readonly MongoDbClient client = new MongoDbClient();
    
    public Repository(IDatabaseNameProvider databaseNameProvider): base(client, databaseNameProvider, new Client{ Id = Guid.Parse("4bf22a7b-36ab-4d84-9723-bc3b7ebe2df2")})
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

    public async Task<List<T>> GetAll()
    {
        var result = await Collection.FindAsync(_=> true);

        return await result.ToListAsync();
    }
}