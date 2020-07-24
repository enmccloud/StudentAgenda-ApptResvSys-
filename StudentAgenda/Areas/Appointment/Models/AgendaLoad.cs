using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace StudentAgenda.Areas.Appointment.Models
{
    public static class AgendaLoad
    {
        public static IWebHost InitializeDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory =
             (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AgendaContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                AgendaSeeder.Seed(dbContext);
            }

            return webHost;
        }
    }
}
