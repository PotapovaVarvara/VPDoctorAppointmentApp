using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DomainModels.Messaging
{
    public enum MessageType
    {
        [Description("register")]
        Register,
        [Description("registerStart")]
        RegisterStart,
        [Description("add appointment")]
        AddAppointment,
        [Description("my appointments")]
        GetActualAppointments,
        [Description("my all appointments appointments")]
        GetAllAppointments,
        [Description("get attachemnts")]
        GetAttachments
    }
    
    public static class MessageTypeExtensions 
    {
        public static string Description(this MessageType type) 
        {
            return GetEnumDescription(type);
        }
        
        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}