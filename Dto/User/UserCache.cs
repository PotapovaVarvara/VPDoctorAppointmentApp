using System;

namespace Dto.User
{
    public class UserCache
    {
        public long TelegramId { set; get; }
        
        public string Name { set; get; }
        
        public string Surname { set; get; }
        
        public DateTime DOB { set; get; }
    }
}