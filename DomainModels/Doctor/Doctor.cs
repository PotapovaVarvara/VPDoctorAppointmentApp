using System;
using System.Collections.Generic;
using DomainModels.Identity;
using DomainModels.Schedule;

namespace DomainModels.Doctor
{
    public class Doctor: Entity
    {
        public DoctorSpeciality Speciality { set; get; }
        
        public User User { set; get; }
        
        public List<ScheduleItem> Schedule { set; get; }
    }
}