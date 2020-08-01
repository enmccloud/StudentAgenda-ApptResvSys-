using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Areas.Teacher.Models;

namespace StudentAgenda.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        private TeacherContext context { get; set; }

        public HomeController(TeacherContext ctx)
        {
            context = ctx;
        }

        [Authorize]
        public IActionResult Index()
        {
            var Teacherss = context.Teachers
                .OrderBy(m => m.Name).ToList();
            return View(Teacherss);
        }
    }
}
