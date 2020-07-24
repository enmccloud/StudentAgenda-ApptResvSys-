using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAgenda.Areas.Appointment.Models
{
    public class AgendaContext : DbContext
    {

        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }
        public DbSet<AgendaAppointment> Appointments { get; set; }
    }
}
