namespace Repository.Infrastructure;

public interface IDatabaseNameProvider
{
    string Get();
}

public class DatabaseNameProvider: IDatabaseNameProvider
{
    public string Get()
    {
        throw new NotImplementedException();
    }
}