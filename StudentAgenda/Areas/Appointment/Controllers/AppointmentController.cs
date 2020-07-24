using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Areas.Appointment.Models;

namespace StudentAgenda.Areas.Appointment.Controllers
{
    [Area("Appointment")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AgendaContext _context;
        public AppointmentController(AgendaContext context)
        {
            _context = context;
        }

        // GET api/events
        [HttpGet]
        public IEnumerable<APIAppointment> Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return _context.Appointments
                .Where(e => e.StartDate < to && e.EndDate >= from)
                .ToList()
                .Select(e => (APIAppointment)e);
        }

        // GET api/events/5
        [HttpGet("{id}")]
        public APIAppointment Get(int id)
        {
            return (APIAppointment)_context
                .Appointments
                .Find(id);
        }

        // POST api/events
        [HttpPost]
        public ObjectResult Post([FromForm] APIAppointment apiAppt)
        {
            var newAppt = (AgendaAppointment)apiAppt;

            _context.Appointments.Add(newAppt);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newAppt.Id,
                action = "inserted"
            });
        }

        // PUT api/events/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromForm] APIAppointment apiAppt)
        {
            var updatedAppt = (AgendaAppointment)apiAppt;
            var dbAppt = _context.Appointments.Find(id);
            dbAppt.Name = updatedAppt.Name;
            dbAppt.StartDate = updatedAppt.StartDate;
            dbAppt.EndDate = updatedAppt.EndDate;
            _context.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // DELETE api/events/5
        [HttpDelete("{id}")]
        public ObjectResult DeleteAppt(int id)
        {
            var e = _context.Appointments.Find(id);
            if (e != null)
            {
                _context.Appointments.Remove(e);
                _context.SaveChanges();
            }

            return Ok(new
            {
                action = "deleted"
            });
        }
    }
}
