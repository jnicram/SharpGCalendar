using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public abstract class Scheduler : ISchedule
    {
        protected RepeatFrequency repeatFrequency;
        protected int interval;

        public Scheduler(RepeatFrequency repeatFrequency, int interval)
        {
            Ensure.That(() => interval).IsGte(1);

            this.repeatFrequency = repeatFrequency;
            this.interval = interval;
        }

        public abstract IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate);
    }
}
