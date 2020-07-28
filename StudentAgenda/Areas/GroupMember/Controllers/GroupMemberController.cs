using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAgenda.Models;
using StudentAgenda.Areas.GroupMember.Models;

namespace StudentAgenda.Areas.GroupMember.Controllers
{
    [Area("GroupMember")]
    public class GroupMemberController : Controller
    {
        private readonly GroupMembersContext _context;

        public GroupMemberController(GroupMembersContext context)
        {
            _context = context;
        }

        // GET: Group Members
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupMembers.ToListAsync());
        }

        // GET: GroupMember/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembers = await _context.GroupMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupMembers == null)
            {
                return NotFound();
            }

            return View(groupMembers);
        }

        // GET: GroupMember/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupMember/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] GroupMembers groupMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupMembers);
        }

        // GET: GroupMember/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembers = await _context.GroupMembers.FindAsync(id);
            if (groupMembers == null)
            {
                return NotFound();
            }
            return View(groupMembers);
        }

        // POST: GroupMember/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] GroupMembers groupMembers)
        {
            if (id != groupMembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupMembersExists(groupMembers.Id))
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
            return View(groupMembers);
        }

        // GET: GroupMember/Delete
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembers = await _context.GroupMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupMembers == null)
            {
                return NotFound();
            }

            return View(groupMembers);
        }

        // POST: GroupMember/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupMembers = await _context.GroupMembers.FindAsync(id);
            _context.GroupMembers.Remove(groupMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupMembersExists(int id)
        {
            return _context.GroupMembers.Any(e => e.Id == id);
        }
    }
}
