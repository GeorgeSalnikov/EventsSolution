using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventsSolution.DAL
{
    public class Event
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }

    }
}
//'ControllerBase' is an ambiguous reference between 'Microsoft.AspNetCore.Mvc.ControllerBase' and 'System.Web.Mvc.ControllerBase'
    