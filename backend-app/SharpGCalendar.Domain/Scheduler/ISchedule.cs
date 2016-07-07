using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public interface ISchedule
    {
        IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate);
    }
}
