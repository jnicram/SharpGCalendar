using SharpGCalendar.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGCalendar.Repository
{
    public class EventsRepository : IEventsRepository
    {
        static List<Event> Events = new List<Event>();

        public void Add(Event item)
        {
            Events.Add(item);
        }

        public Event Get(int id)
        {
            return Events
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Event> Find(DateTime startDateTime, DateTime endDateTime)
        {
            return Events.FindAll(x => x.StartDateTime >= startDateTime && x.EndDateTime < endDateTime);
        }

        public void Remove(int id)
        {
            var itemToRemove = Events.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                Events.Remove(itemToRemove);
            }          
        }

        public void Update(Event item)
        {
            var itemToUpdate = Events.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Title = item.Title;
                itemToUpdate.StartDateTime = item.StartDateTime;
                itemToUpdate.EndDateTime = item.EndDateTime;
                itemToUpdate.Location = item.Location;
                itemToUpdate.Description = item.Description;
                itemToUpdate.Color = item.Color;
            }
        }
    }
}
