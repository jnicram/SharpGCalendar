using System;
using System.Collections.Generic;

namespace SharpGCalendar.Models.Scheduler
{
    public interface ISchedule
    {
        IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate);
    }
}
