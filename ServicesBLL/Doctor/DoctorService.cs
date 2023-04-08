using DomainModels.Identity;
using Dto;
using Repository.Doctor;

namespace ServicesBLL.Doctor
{
    public interface IDoctorService
    {
        Task AddAsync(AddDoctorDto dto);
        
        Task<List<DomainModels.Doctor.Doctor>> GetAll();
    }
    
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task AddAsync(AddDoctorDto dto)
        {
            dto.User.Id = Guid.NewGuid();
            
            await _doctorRepository.AddOneAsync(new DomainModels.Doctor.Doctor
            {
                User = dto.User,
                Speciality = dto.Speciality,
                Id = Guid.NewGuid(),
                Schedule = dto.Schedule
            });
        }

        public async Task<List<DomainModels.Doctor.Doctor>> GetAll()
        {
            return await _doctorRepository.GetAll();
        }
    }
}