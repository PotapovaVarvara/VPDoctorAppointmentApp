using DomainModels;

namespace Repository.Infrastructure;

public abstract class RepositoryBase<T> : Repository<T> where T : Entity
{
    protected RepositoryBase(IDatabaseNameProvider databaseNameProvider) : base(databaseNameProvider)
    {
    }
}