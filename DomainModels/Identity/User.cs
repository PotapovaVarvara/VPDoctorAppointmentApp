using System;

namespace DomainModels.Identity
{
    public class User : UserBase
    {
        public string Name { set; get; }
        
        public string Surname { set; get; }
        
        public DateTime DOB { set; get; }
        
        public string PhoneNumber { set; get; }

        public User(string name, string surname, DateTime dob, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            DOB = dob;
            PhoneNumber = phoneNumber;
           
        }
    }
}