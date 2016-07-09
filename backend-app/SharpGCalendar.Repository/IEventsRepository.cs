using SharpGCalendar.Domain.Model;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Repository
{
    public interface IEventsRepository
    {
        void Add(Event item);

        IEnumerable<Event> Find(DateTime startDateTime, DateTime endDateTim);

        Event Get(int id);

        void Remove(int id);

        void Update(Event item);
    }
}
