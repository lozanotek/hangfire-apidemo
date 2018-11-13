using System;

namespace HangfireDemo.Services
{
    public class DateService : IDateService
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public DateTime GetNow()
        {
            return DateTime.Now;
        }

        public DateTime GetNowUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
