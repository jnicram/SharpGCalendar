using SharpGCalendar.Repository;
using System;
using System.Collections.Generic;
using SharpGCalendar.Domain.Model;
using SharpGCalendar.Domain;

namespace SharpGCalendar.Service
{
    public class EventsService : IEventsService
    {
        private IEventsRepository eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public IEnumerable<EventDto> Find(DateTime startDate, DateTime endDate)
        {
            List<EventDto> result = new List<EventDto>();
            IEnumerable<Event> events = eventsRepository.Find(startDate, endDate);
            foreach (Event item in events)
            {
                result.Add(item.Convert());
            }

            return result;
        }

        public EventDto GetById(int id)
        {
            Event item = eventsRepository.Get(id);
            if (item != null)
            {
                return item.Convert();
            }

            return null;
        }

        public EventDto Create(EventDto item)
        {
            if (item != null)
            {
                return eventsRepository.Add(item.Convert()).Convert();
            }

            return null;
        }

        public EventDto Update(EventDto item)
        {
            var eventItem = eventsRepository.Get(item.Id);
            if (eventItem != null)
            {
                return eventsRepository.Update(item.Convert()).Convert();
            }

            return null;
        }

        public void Delete(int id)
        {
            eventsRepository.Remove(id);
        }
    }
}
