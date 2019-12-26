using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsSolution.BL;
using EventsSolution.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsSolution.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventsService _eventService;
            
        public EventsController(IEventsService eventService)
            => _eventService = eventService;

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventService.GetAllEvents();
        }

        // GET: api/Events/4
        [HttpGet("{id}", Name = "Get")]
        public Event GetEvent([FromRoute] int id)
        {
            return _eventService.GetEvent(id);
        }

       // POST: api/Events
       //[HttpPost]
       // public void Post([FromBody] string value)
       // {
       // }

       // PUT: api/Events/5
       // [HttpPut("{id}")]
       // public void Put(int id, [FromBody] string value)
       // {
       // }

       // DELETE: api/ApiWithActions/5
       // [HttpDelete("{id}")]
       // public void Delete(int id)
       // {
       // }
    }
}
