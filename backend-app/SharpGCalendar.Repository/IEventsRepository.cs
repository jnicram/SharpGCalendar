using SharpGCalendar.Domain.Model;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Repository
{
    public interface IEventsRepository
    {
        Event Add(Event item);

        IEnumerable<Event> Find(DateTime startDateTime, DateTime endDateTim);

        Event Get(int id);

        void Remove(int id);

        Event Update(Event item);
    }
}
