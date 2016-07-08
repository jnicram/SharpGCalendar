﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharpGCalendar.Repository;
using SharpGCalendar.Domain;
using System;

namespace SharpGCalendar.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        public IEventsRepository EventsRepo { get; set; }

        public EventsController(IEventsRepository _repo)
        {
            EventsRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return EventsRepo.Find(DateTime.Today, DateTime.Today.AddDays(1));
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetById(string id)
        {
            var item = EventsRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Event item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            EventsRepo.Add(item);
            return CreatedAtRoute("GetEvent", new { Controller = "Events", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Event item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var eventItem = EventsRepo.Get(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            EventsRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            EventsRepo.Remove(id);
        }
    }
}