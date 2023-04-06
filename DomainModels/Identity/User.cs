using System;

namespace DomainModels.Identity
{
    public class User : UserBase
    {
        public string Name { set; get; }
        
        public string Surname { set; get; }
        
        public DateTime DOB { set; get; }
    }
}