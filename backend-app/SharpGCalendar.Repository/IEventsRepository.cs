using SharpGCalendar.Domain;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Repository
{
    public interface IEventsRepository
    {
        void Add(Event item);

        IEnumerable<Event> Find(DateTime startDateTime, DateTime endDateTim);

        Event Get(string key);

        void Remove(string key);

        void Update(Event item);
    }
}
