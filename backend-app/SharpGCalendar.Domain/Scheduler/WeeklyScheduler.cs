using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public class WeeklyScheduler : Scheduler
    {
        public WeeklyScheduler(int interval) : this(RepeatFrequency.None, interval)
        {
        }

        public WeeklyScheduler(RepeatFrequency repeatFrequency, int interval) : base(repeatFrequency, interval)
        {
        }

        public override IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate)
        {
            Ensure.That(() => endDate).IsGte(startDate);

            IEnumerable<DateTime> occurrences = new List<DateTime>();

            switch (repeatFrequency)
            {
                case RepeatFrequency.None:
                    occurrences = DetermineOccurences(startDate, endDate);
                    break;
                default:
                    occurrences = DetermineOccurencesWithRepeatingFrequency(startDate, endDate);
                    break;
            }

            return occurrences;
        }

        private IEnumerable<DateTime> DetermineOccurences(DateTime startDate, DateTime endDate)
        {
            List<DateTime> occurrences = new List<DateTime>();

            for (DateTime dateTime = startDate; dateTime < endDate; dateTime = dateTime.AddDays(7 * interval))
            {
                occurrences.Add(dateTime);
            }

            return occurrences;
        }

        private IEnumerable<DateTime> DetermineOccurencesWithRepeatingFrequency(DateTime startDate, DateTime endDate)
        {
            List<DateTime> occurrences = new List<DateTime>();
            IEnumerable<DayOfWeek> daysOfWeek = DetermineDaysOfWeek();

            foreach (var dayOfWeek in daysOfWeek)
            {
                DateTime start = startDate.GetNthWeekday(dayOfWeek, interval);
                for (DateTime dateTime = start; dateTime < endDate; dateTime = dateTime.AddDays(7 * interval))
                {
                    occurrences.Add(dateTime);
                }
            }

            return occurrences;
        }

        private IEnumerable<DayOfWeek> DetermineDaysOfWeek()
        {
            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();

            if ((repeatFrequency & RepeatFrequency.Monday) == RepeatFrequency.Monday)
            {
                daysOfWeek.Add(DayOfWeek.Monday);
            }

            if ((repeatFrequency & RepeatFrequency.Tuesday) == RepeatFrequency.Tuesday)
            {
                daysOfWeek.Add(DayOfWeek.Tuesday);
            }

            if ((repeatFrequency & RepeatFrequency.Wednesday) == RepeatFrequency.Wednesday)
            {
                daysOfWeek.Add(DayOfWeek.Wednesday);
            }

            if ((repeatFrequency & RepeatFrequency.Thursday) == RepeatFrequency.Thursday)
            {
                daysOfWeek.Add(DayOfWeek.Thursday);
            }

            if ((repeatFrequency & RepeatFrequency.Friday) == RepeatFrequency.Friday)
            {
                daysOfWeek.Add(DayOfWeek.Friday);
            }

            if ((repeatFrequency & RepeatFrequency.Saturday) == RepeatFrequency.Saturday)
            {
                daysOfWeek.Add(DayOfWeek.Saturday);
            }

            if ((repeatFrequency & RepeatFrequency.Sunday) == RepeatFrequency.Sunday)
            {
                daysOfWeek.Add(DayOfWeek.Sunday);
            }

            return daysOfWeek;
        }
    }
}
