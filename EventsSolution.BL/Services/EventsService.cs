using EventsSolution.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSolution.BL
{
    public class EventsService : IEventsService
    {
        private readonly EventsDbContext _context;

        public EventsService(EventsDbContext context)
            => _context = context;

        public IEnumerable<Event> GetAllEvents()
            => _context.Events.Select(ev => new Event { Id = ev.Id, Title = ev.Title, Description = ev.Description, Date = ev.Date, Type = new EventType { Id = ev.Type.Id, Title = ev.Type.Title, } });

        public Event GetEvent(int id)
            => _context.Events.Include(ev => ev.Type).First(ev => ev.Id == id);
    }
}
