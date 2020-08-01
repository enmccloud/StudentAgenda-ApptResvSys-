using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAgenda.Areas.Appointment.Models
{
    public class AgendaSeeder
    {
        public static void Seed(AgendaContext context)
        {
            if (context.Appointments.Any())
            {
                return;   // DB has been seeded
            }

            var appointments = new List<AgendaAppointment>()
            {
                new AgendaAppointment
                {
                    Name = "Appointment 1",
                    StartDate = new DateTime(2020, 1, 15, 2, 0, 0),
                    EndDate = new DateTime(2020, 1, 15, 4, 0, 0)
                },
                new AgendaAppointment()
                {
                    Name = "Appointment 2",
                    StartDate = new DateTime(2020, 1, 17, 3, 0, 0),
                    EndDate = new DateTime(2020, 1, 17, 6, 0, 0)
                },
                new AgendaAppointment()
                {
                    Name = "Ongoing Appointment",
                    StartDate = new DateTime(2020, 1, 15, 0, 0, 0),
                    EndDate = new DateTime(2020, 1, 20, 0, 0, 0)
                }
            };

            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();
        }
    }
}