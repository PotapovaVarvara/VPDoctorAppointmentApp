using System;
using DomainModels.Doctor;

namespace Dto
{
    public class AddDoctorDto
    {
        public Guid ClientId { set; get; }
        
        public DoctorSpeciality Speciality { set; get; }
        
        public DomainModels.Identity.User User { set; get; }
    }
}