using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAgenda.Models;
using StudentAgenda.Areas.Class.Models;

namespace StudentAgenda.Areas.Class.Controllers
{
    [Area("Class")]
    public class HomeController : Controller
    {
        private  ClassContext context { get; set; }

        public HomeController(ClassContext ctx)
        {
            context = ctx;
        }

        [Authorize]
        public IActionResult Index()
        {
            var classes = context.Classes
                .OrderBy(m => m.Name).ToList();
            return View(classes);
        }
    }
}
