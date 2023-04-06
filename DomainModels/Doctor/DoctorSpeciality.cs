using System.ComponentModel;

namespace DomainModels.Doctor
{
    public enum DoctorSpeciality
    {
        [Description("Терапевт")]
        Therapeutics = 0,
        [Description("Хірург")]
        Surgery,
        [Description("Ортопед")]
        Orthopedics,
        [Description("Ортодонт")]
        Orthodontics
    }
}