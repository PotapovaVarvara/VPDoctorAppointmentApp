namespace Infrastructure;

public interface IClientNameProvider
{
    Task Set(string name);

    Task<string> Get();
}

public class ClientNameProvider: IClientNameProvider
{
    public Task Set(string name)
    {
        throw new NotImplementedException();
    }

    public Task<string> Get()
    {
        throw new NotImplementedException();
    }
}