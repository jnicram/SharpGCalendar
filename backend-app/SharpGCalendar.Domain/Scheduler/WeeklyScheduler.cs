using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public class WeeklyScheduler : Scheduler
    {
        private WeeklyRepeatType repeatFrequency;

        public WeeklyScheduler(WeeklyRepeatType repeatFrequency, int interval) : base(interval)
        {
            this.repeatFrequency = repeatFrequency;
        }

        public override IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate)
        {
            Ensure.That(() => endDate).IsGte(startDate);

            IEnumerable<DateTime> occurrences = new List<DateTime>();

            if (repeatFrequency == WeeklyRepeatType.None)
            {
                occurrences = DetermineOccurences(startDate, endDate);
            }
            else
            {
                occurrences = DetermineOccurencesWithRepeatingFrequency(startDate, endDate);
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

            if ((repeatFrequency & WeeklyRepeatType.Monday) == WeeklyRepeatType.Monday)
            {
                daysOfWeek.Add(DayOfWeek.Monday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Tuesday) == WeeklyRepeatType.Tuesday)
            {
                daysOfWeek.Add(DayOfWeek.Tuesday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Wednesday) == WeeklyRepeatType.Wednesday)
            {
                daysOfWeek.Add(DayOfWeek.Wednesday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Thursday) == WeeklyRepeatType.Thursday)
            {
                daysOfWeek.Add(DayOfWeek.Thursday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Friday) == WeeklyRepeatType.Friday)
            {
                daysOfWeek.Add(DayOfWeek.Friday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Saturday) == WeeklyRepeatType.Saturday)
            {
                daysOfWeek.Add(DayOfWeek.Saturday);
            }

            if ((repeatFrequency & WeeklyRepeatType.Sunday) == WeeklyRepeatType.Sunday)
            {
                daysOfWeek.Add(DayOfWeek.Sunday);
            }

            return daysOfWeek;
        }
    }
}
