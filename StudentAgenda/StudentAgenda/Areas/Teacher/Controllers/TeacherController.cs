using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Teacher.Models;
using StudentAgenda.Repository;

namespace StudentAgenda.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherController : Controller
    {

        readonly TeacherContext _context;
        private readonly ITeacherRepository teacherRepository;
        private readonly IClassRepository classRepository;

        public TeacherController(ITeacherRepository teacherRepository, IClassRepository classRepository)
        {
            this.teacherRepository = teacherRepository;
            this.classRepository = classRepository;
            //_context = context;
        }

        //Get Teachers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var ClassContext = _context.Teachers.Include(c => c.Classes);
            //return View(await ClassContext.ToListAsync());
            return View(await teacherRepository.GetAllAsync());
        }

        // GET: Teacher/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await teacherRepository.GetByIdAsync(id.Value);
            //var teacher = await _context.Teachers
            //    .Include(c => c.Classes)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewData["ClassId"] = new SelectList(await classRepository.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,ClassId")] Teachers teacher)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(teacher);
                //await _context.SaveChangesAsync();
                await teacherRepository.InsertAsync(teacher);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(await classRepository.GetAllAsync(), "Id", "Id", teacher.ClassId);
            return View(teacher);
        }

        // GET: Teachers/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await teacherRepository.GetByIdAsync(id.Value);
           // var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }           
            ViewData["ClassId"] = new SelectList(await classRepository.GetAllAsync(), "Id", "Id", teacher.ClassId);
            return View(teacher);
        }

        // POST: Teachers/Edit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,ClassId")] Teachers teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", teacher.ClassId);
            ViewData["ClassId"] = new SelectList(await classRepository.GetAllAsync(), "Id", "Id", teacher.ClassId);
            return View(teacher);
        }

        // GET: Teachers/Delete
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await teacherRepository.GetByIdAsync(id.Value);
              //var teachers = await _context.Teachers
             //   .Include(c => c.Classes)
             //   .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await teacherRepository.GetByIdAsync(id);
            //var teachers = await _context.Teachers.FindAsync(id);
            
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
