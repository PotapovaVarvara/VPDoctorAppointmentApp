using Dto.User;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace VPDoctorAppointmentApp.Cache;

public interface ICacheRegistrationService
{
    Task<UserCache> Get(long telegramId);
    
    Task Set(long telegramId, UserCache userCache);
    
    Task<bool> InProcess(long telegramId);
}

public class CacheRegistrationService: ICacheRegistrationService
{
    private readonly IDistributedCache _cache;
    
    public CacheRegistrationService(
        IDistributedCache distributedCache)
    {
        _cache = distributedCache;
    }
    
    public async Task<UserCache> Get(long telegramId)
    {
        return await GetInternal(telegramId) ?? new UserCache();
    } 

    public async Task Set(long telegramId, UserCache userCache)
    {
        var userString = JsonSerializer.Serialize(userCache);
        
        await _cache.SetStringAsync(telegramId.ToString(), userString, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        });
    }

    public async Task<bool> InProcess(long telegramId)
    {
        return await GetInternal(telegramId) == null;
    }

    private async Task<UserCache?> GetInternal(long telegramId)
    {
        UserCache? user = null;
        
        var userString = await _cache.GetStringAsync(telegramId.ToString());

        if (userString != null)
        {
            user = JsonSerializer.Deserialize<UserCache>(userString);
        }

        if (user != null)
        {
            Console.WriteLine($"{user.Name} извлечен из кэша"); 
            return user;
        }

        return user;
    }
}