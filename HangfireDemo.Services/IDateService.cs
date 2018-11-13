using System;

namespace HangfireDemo.Services
{
    public interface IDateService
    {
        DateTime GetToday();
        DateTime GetNow();
        DateTime GetNowUtc();
    }
}
