using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSolution.DAL
{
    public class EventsDbContext : DbContext
    {
        public const string DatabaseName = "EventsSolutionDatabaseName";


        /// <summary>Default ctor for testing in-memory database
        /// </summary>
        public EventsDbContext()
        {
        }

        public EventsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(DatabaseName);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
