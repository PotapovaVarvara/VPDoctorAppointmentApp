using DomainModels.Identity;
using Repository.Infrastructure.User;

namespace Identity;

public interface ICurrentContextSetup
{
    Task Set(long telegramId);
}


public interface ICurrentContext
{
    UserBase User { get; }
}

public class CurrentContext : ICurrentContext, ICurrentContextSetup
{
    public UserBase User { get; private set; }

    private readonly IUserRepository _userRepository;
        
    public CurrentContext(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Set(long telegramId)
    {
        User = await _userRepository.FindByTelegramIdAsync(telegramId);
    }
}