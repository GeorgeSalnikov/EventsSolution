using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsSolution.DAL;
using EventsSolution.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EventsSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string EventsSolutionNGOrigin = "EventsSolutionNGOrigin";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(EventsSolutionNGOrigin, builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<EventsDbContext>(op => op.UseInMemoryDatabase(EventsDbContext.DatabaseName));
            services.AddScoped<IEventsService, EventsService>(); 
            services.AddScoped<UtilityService, UtilityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var utilSvc = scope.ServiceProvider.GetRequiredService<UtilityService>();

                    // initialize in-memory database with test data
                    utilSvc.PopulateRepoWithTestData();
                }
            }

            app.UseCors(EventsSolutionNGOrigin); 
            app.UseMvc();
        }
    }
}
