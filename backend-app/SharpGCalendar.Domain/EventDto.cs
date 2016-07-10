using SharpGCalendar.Domain.Model;
using System;

namespace SharpGCalendar.Domain
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime? SeriesEndDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Color { get; set; }

        public int FrequencyType { get; set; }

        public int MonthlyRepeatType { get; set; }

        public int WeeklyRepeatType { get; set; }

        public int FrequencyInterval { get; set; }       

        public Event Convert()
        {
            return new Event()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                EndDateTime = EndDateTime,
                StartDateTime = StartDateTime,
                SeriesEndDate = SeriesEndDate,
                FrequencyInterval = FrequencyInterval,
                Location = Location,
                Color = (Color) Enum.ToObject(typeof(Color), Color),
                FrequencyType = (Frequency) Enum.ToObject(typeof(Frequency), FrequencyType),
                MonthlyRepeatType = (MonthlyRepeatType) Enum.ToObject(typeof(MonthlyRepeatType), MonthlyRepeatType),
                WeeklyRepeatType = (WeeklyRepeatType) Enum.ToObject(typeof(WeeklyRepeatType), WeeklyRepeatType)
            };
        }
    }
}
