using System;
using DomainModels.Identity;

namespace DomainModels.Doctor
{
    public class Doctor: Entity
    {
        public Guid SpecialityId { set; get; }
        
        public User User { set; get; }
    }
}