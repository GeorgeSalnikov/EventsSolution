using EventsSolution.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSolution.BL
{
    public interface IEventsService
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEvent(int id);
    }
}
