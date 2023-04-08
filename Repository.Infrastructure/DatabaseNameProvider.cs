namespace Repository.Infrastructure;

public interface IDatabaseNameProvider
{
    string Get(Guid id);
}

public class DatabaseNameProvider: IDatabaseNameProvider
{
    public string Get(Guid id)
    {
        return $"VPClient_{id.ToString()}";
    }
}