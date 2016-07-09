using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public class MonthlyScheduler : Scheduler
    {
        private MonthlyRepeatType repeatFrequency;

        public MonthlyScheduler(MonthlyRepeatType repeatFrequency, int interval) : base(interval)
        {
            this.repeatFrequency = repeatFrequency;
        }

        public override IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate)
        {
            Ensure.That(() => endDate).IsGte(startDate);

            IEnumerable<DateTime> occurrences = new List<DateTime>();

            switch (repeatFrequency)
            {
                case MonthlyRepeatType.DayOfWeek:
                    occurrences = DetermineOccurencesWithDayOfWeekRepeating(startDate, endDate);
                    break;
                case MonthlyRepeatType.DayOfMonth:
                    occurrences = DetermineOccurencesWithDayOfMonthRepeating(startDate, endDate);
                    break;
            }
        
            return occurrences;
        }

        private IEnumerable<DateTime> DetermineOccurencesWithDayOfMonthRepeating(DateTime startDate, DateTime endDate)
        {
            List<DateTime> occurrences = new List<DateTime>();

            for (DateTime dateTime = startDate; dateTime < endDate; dateTime = dateTime.AddMonths(interval))
            {
                occurrences.Add(dateTime);
            }

            return occurrences;
        }

        private IEnumerable<DateTime> DetermineOccurencesWithDayOfWeekRepeating(DateTime startDate, DateTime endDate)
        {
            List<DateTime> occurrences = new List<DateTime>();       
            int dayOfWeek = (int) Math.Ceiling(startDate.Day / 7m);

            for (DateTime dateTime = startDate; dateTime < endDate; dateTime = dateTime.AddMonths(interval))
            {
                DateTime occurrence  = new DateTime(dateTime.Year, dateTime.Month, 1).Next(startDate.DayOfWeek).AddDays((dayOfWeek - 1) * 7);
                occurrences.Add(occurrence.Add(dateTime.TimeOfDay));             
            }

            return occurrences;
        }
    }
}
