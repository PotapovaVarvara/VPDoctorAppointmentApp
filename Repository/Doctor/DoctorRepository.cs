using Repository.Infrastructure;

namespace Repository.Doctor
{
    public interface IDoctorRepository
    {
        
    }
    
    public class DoctorRepository: RepositoryBase<DomainModels.Doctor.Doctor>, IDoctorRepository
    {
        public DoctorRepository(IDatabaseNameProvider databaseNameProvider) : base(databaseNameProvider)
        {
        }
    }
}