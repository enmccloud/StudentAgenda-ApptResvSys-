using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Areas.Appointment.Models;


namespace StudentAgenda.Areas.Appointment.Controllers
{
    [Area("Appointmnent")]
    public class HomeController : Controller
    {
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
