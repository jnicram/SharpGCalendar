using Microsoft.AspNetCore.Mvc;
using SharpGCalendar.Domain;
using SharpGCalendar.Service;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private IEventsService eventsService;

        public EventsController(IEventsService service)
        {
            eventsService = service;
        }

        [HttpGet]
        public IEnumerable<EventDto> GetAll()
        {
            return eventsService.Find(DateTime.Today, DateTime.Today.AddDays(1));
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetById(int id)
        {
            EventDto item = eventsService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EventDto item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            EventDto createdEvent = eventsService.Create(item);

            return CreatedAtRoute("GetEvent", new { Controller = "Events", id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EventDto item)
        {
            EventDto eventItem = eventsService.Update(item);
            if (eventItem == null)
            {
                return NotFound();
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            eventsService.Delete(id);
        }
    }
}
