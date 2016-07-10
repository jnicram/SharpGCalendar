using SharpGCalendar.Domain.Scheduler;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Model
{
    public class Event : ICloneable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime? SeriesEndDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public Color Color { get; set; }

        public Frequency FrequencyType { get; set; }

        public MonthlyRepeatType MonthlyRepeatType { get; set; }

        public WeeklyRepeatType WeeklyRepeatType { get; set; }

        public int FrequencyInterval { get; set; }

        public IEnumerable<DateTime> GetSeriesOccurrences(DateTime endDateTime)
        {
            IEnumerable<DateTime> occurrences = new List<DateTime>();
            ISchedule scheduler = null;

            switch (FrequencyType)
            {
                case Frequency.Weekly:
                    scheduler = new WeeklyScheduler(WeeklyRepeatType, FrequencyInterval);
                    break;
                case Frequency.Monthly:
                    scheduler = new MonthlyScheduler(MonthlyRepeatType, FrequencyInterval);
                    break;
                case Frequency.Yearly:
                    scheduler = new YearlyScheduler(FrequencyInterval);
                    break;
                case Frequency.Daily:
                default:
                    scheduler = new DailyScheduler(FrequencyInterval);
                    break;
            }

            occurrences = scheduler.GetOccurrences(StartDateTime, DetermineEndEventDate(endDateTime));

            return occurrences;
        }

        public EventDto Convert()
        {
            return new EventDto()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                EndDateTime = EndDateTime,
                StartDateTime = StartDateTime,
                SeriesEndDate = SeriesEndDate,
                FrequencyInterval = FrequencyInterval,
                Location = Location,
                Color = (int) Color,
                FrequencyType = (int) FrequencyType,
                MonthlyRepeatType = (int) MonthlyRepeatType,
                WeeklyRepeatType = (int) WeeklyRepeatType
            };
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private DateTime DetermineEndEventDate(DateTime endDateTime)
        {
            return SeriesEndDate.HasValue ? 
                (SeriesEndDate.Value < endDateTime ? SeriesEndDate.Value : endDateTime) : endDateTime;
        }
    }
}
