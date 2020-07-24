using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StudentAgenda.Controllers
{
    public class ClassController : Controller
    {
        private readonly ClassContext _context;
        public ClassController(ClassContext context)
        {
            _context = context;
        }

        // GET: Classes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: Classes/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        // GET: Classes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CourseDescription")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classes);
        }

        // GET: Classes/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }

        // POST: Classes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CourseDescription")] Classes classes)
        {
            if (id != classes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesExists(classes.Id))
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
            return View(classes);
        }

        // GET: Classes/Delete
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        // POST: Classes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classes = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
