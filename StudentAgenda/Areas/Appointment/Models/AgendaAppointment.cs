using System;

namespace StudentAgenda.Areas.Appointment.Models
{
    public class AgendaAppointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
