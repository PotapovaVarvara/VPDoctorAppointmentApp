using System;

namespace DomainModels.Schedule
{
    public class ScheduleItem
    {
        public Day Day { set; get; }
        
        public int TimeStart { set; get; }
        
        public int TimeFinish { set; get; }
    }
}