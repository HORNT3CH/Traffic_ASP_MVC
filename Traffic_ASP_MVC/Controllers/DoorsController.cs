using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Data;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Controllers
{
    public class DoorsController : Controller
    {
        private readonly Traffic_Door_Context _context;

        public DoorsController(Traffic_Door_Context context)
        {
            _context = context;
        }

        // GET: Doors
        public async Task<IActionResult> Index()
        {
            return _context.Doors != null ?
                        View(await _context.Doors.ToListAsync()) :
                        Problem("Entity set 'Traffic_Door_Context.Doors'  is null.");
        }

        // GET: Doors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doors == null)
            {
                return NotFound();
            }

            var doors = await _context.Doors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doors == null)
            {
                return NotFound();
            }

            return View(doors);
        }

        // GET: Doors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,location,status")] Doors doors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doors);
        }

        // GET: Doors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doors == null)
            {
                return NotFound();
            }

            var doors = await _context.Doors.FindAsync(id);
            if (doors == null)
            {
                return NotFound();
            }
            return View(doors);
        }

        // POST: Doors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,location,status")] Doors doors)
        {
            if (id != doors.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoorsExists(doors.ID))
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
            return View(doors);
        }

        // GET: Doors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doors == null)
            {
                return NotFound();
            }

            var doors = await _context.Doors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doors == null)
            {
                return NotFound();
            }

            return View(doors);
        }

        // POST: Doors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doors == null)
            {
                return Problem("Entity set 'Traffic_Door_Context.Doors'  is null.");
            }
            var doors = await _context.Doors.FindAsync(id);
            if (doors != null)
            {
                _context.Doors.Remove(doors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoorsExists(int id)
        {
          return (_context.Doors?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
