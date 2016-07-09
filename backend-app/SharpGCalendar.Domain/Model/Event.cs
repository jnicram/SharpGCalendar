using System;

namespace SharpGCalendar.Domain.Model
{
    public class Event
    {
        public string Key { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public Color Color { get; set; }
    }
}
