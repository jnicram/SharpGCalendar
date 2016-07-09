using LiteDB;
using SharpGCalendar.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGCalendar.Repository
{
    public class EventsRepository : IEventsRepository
    {
        const string DB_NAME = @"../../data/SharpGCalendar.db";

        public void Add(Event item)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var events = db.GetCollection<Event>("events");
                events.Insert(item);               
            }
        }

        public Event Get(int id)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var events = db.GetCollection<Event>("events");
                return events.FindOne(e => e.Id == id);
            }
        }

        public IEnumerable<Event> Find(DateTime startDateTime, DateTime endDateTime)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var events = db.GetCollection<Event>("events");

                // @TODO Problem with Find by date 
                // return events.Find(e => e.StartDateTime >= startDateTime && e.EndDateTime < endDateTime);

                return events
                    .FindAll().ToList()
                    .FindAll(x => x.StartDateTime >= startDateTime && x.EndDateTime < endDateTime);
            }
        }

        public void Remove(int id)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var events = db.GetCollection<Event>("events");
                events.Delete(e => e.Id == id);
            }         
        }

        public void Update(Event item)
        {
            using (var db = new LiteDatabase(DB_NAME))
            {
                var events = db.GetCollection<Event>("events");
                Event itemToUpdate = events.FindOne(e => e.Id == item.Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Title = item.Title;
                    itemToUpdate.StartDateTime = item.StartDateTime;
                    itemToUpdate.EndDateTime = item.EndDateTime;
                    itemToUpdate.Location = item.Location;
                    itemToUpdate.Description = item.Description;
                    itemToUpdate.Color = item.Color;

                    events.Update(itemToUpdate);
                }
            }
        }
    }
}
