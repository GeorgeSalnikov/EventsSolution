using EventsSolution.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSolution.BL
{
    public class UtilityService
    {
        private EventsDbContext _context;

        public UtilityService(EventsDbContext context)
            => _context = context;

        public void PopulateRepoWithTestData()
        {
            var meetEventType = new EventType { Title = "Meeting", Description = "Meeting event type" };
            var apptEventType = new EventType { Title = "Appointment", Description = "Appointment event type" };

            _context.AddRange(new[] { meetEventType, apptEventType });
            _context.AddRange(new[] 
            { 
                new Event {Title = "Meeting 1", Description = "Description to Meeting 1", Notes = "Notes to meeting 1", Date = new DateTime(2019, 1, 20), Type = meetEventType },
                new Event {Title = "Appointment 1", Description = "Description to Appointment 1", Notes = "Notes to Appointment 1", Date = new DateTime(2019, 1, 30), Type = apptEventType },
                new Event {Title = "Meeting 2", Description = "Description to Meeting 2", Notes = "Notes to meeting 2", Date = new DateTime(2019, 2, 28), Type = meetEventType },
                new Event {Title = "Appointment 2", Description = "Description to Appointment 2", Notes = "Notes to Appointment 2", Date = new DateTime(2019, 2, 27), Type = apptEventType },
            });

            int numChanges = _context.SaveChanges();
        }
    }
}
