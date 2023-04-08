using System;
using System.Collections.Generic;
using DomainModels.Doctor;
using DomainModels.Schedule;

namespace Dto
{
    public class AddDoctorDto
    {
        public Guid ClientId { set; get; }
        
        public DoctorSpeciality Speciality { set; get; }
        
        public DomainModels.Identity.User User { set; get; }
        
        public List<ScheduleItem> Schedule { set; get; }
    }
}