using SharpGCalendar.Domain;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Service
{
    public interface IEventsService
    {
        IEnumerable<EventDto> Find(DateTime startDate, DateTime endDate);

        EventDto GetById(int id);

        EventDto Create(EventDto item);

        EventDto Update(EventDto item);

        void Delete(int id);
    }
}
