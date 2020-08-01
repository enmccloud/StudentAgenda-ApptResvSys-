using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Areas.Appointment.Models;
using System.Linq;

namespace StudentAgenda.Areas.Appointment.Controllers
{
    [Area("Appointment")]
    public class HomeController : Controller
    {
        private AgendaContext context { get; set; }

        public HomeController(AgendaContext ctx)
        {
            context = ctx;
        }
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Basic
        public ActionResult Scheduler()
        {
            return View();
        }
    }
}
