namespace Repository.Infrastructure.User;

public interface IUserRepository: IRepository<DomainModels.Identity.User>
{
    
}

public class UserRepository : Repository<DomainModels.Identity.User>, IUserRepository
{
    public UserRepository(IDatabaseNameProvider databaseNameProvider) : base(databaseNameProvider)
    {
    }
}