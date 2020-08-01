using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace StudentAgenda.Areas.Appointment.Models
{
    public class APIAppointment
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public static explicit operator APIAppointment(AgendaAppointment appt)
        {
            return new APIAppointment
            {
                id = appt.Id,
                text = HtmlEncoder.Default.Encode(appt.Name),
                start_date = appt.StartDate.ToString("yyyy-MM-dd HH:mm"),
                end_date = appt.EndDate.ToString("yyyy-MM-dd HH:mm")
            };
        }

        public static explicit operator AgendaAppointment(APIAppointment appt)
        {
            return new AgendaAppointment
            {
                Id = appt.id,
                Name = appt.text,
                StartDate = DateTime.Parse(appt.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.Parse(appt.end_date,
                    System.Globalization.CultureInfo.InvariantCulture)
            };
        }
    }
}
