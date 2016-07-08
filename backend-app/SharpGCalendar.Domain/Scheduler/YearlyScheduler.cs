using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public class YearlyScheduler : Scheduler
    {
        public YearlyScheduler(FrequencyPart frequencyPart, int interval) : base(frequencyPart, interval)
        {
        }

        public override IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate)
        {
            Ensure.That(() => endDate).IsGte(startDate);

            List<DateTime> occurrences = new List<DateTime>();

            for (DateTime dateTime = startDate; dateTime < endDate; dateTime = dateTime.AddYears(interval))
            {
                occurrences.Add(dateTime);
            }

            return occurrences;
        }
    }
}
