using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public abstract class Scheduler : ISchedule
    {
        protected FrequencyPart frequencyPart;
        protected int interval;

        public Scheduler(FrequencyPart frequencyPart, int interval)
        {
            Ensure.That(() => interval).IsGte(1);

            this.frequencyPart = frequencyPart;
            this.interval = interval;
        }

        public abstract IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate);
    }
}
