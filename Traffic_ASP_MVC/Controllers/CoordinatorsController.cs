using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Data;
using Traffic_ASP_MVC.Models;
using cloudscribe.Pagination.Models;
namespace Traffic_ASP_MVC.Controllers
{
    public class CoordinatorsController : Controller
    {
        private readonly Traffic_Coordinators_Context _context;

        public CoordinatorsController(Traffic_Coordinators_Context context)
        {
            _context = context;
        }

        // GET: Coordinators
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=500)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var theCoordinator = _context.Coordinators.Skip(ExcludeRecords).Take(pageSize);

            var result = new PagedResult<Coordinators>
            {
                Data = await theCoordinator.AsNoTracking().ToListAsync(),
                TotalItems = _context.Coordinators.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        // GET: Coordinators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coordinators == null)
            {
                return NotFound();
            }

            var coordinators = await _context.Coordinators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinators == null)
            {
                return NotFound();
            }

            return View(coordinators);
        }

        // GET: Coordinators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coordinators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoordinatorName")] Coordinators coordinators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coordinators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coordinators);
        }

        // GET: Coordinators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coordinators == null)
            {
                return NotFound();
            }

            var coordinators = await _context.Coordinators.FindAsync(id);
            if (coordinators == null)
            {
                return NotFound();
            }
            return View(coordinators);
        }

        // POST: Coordinators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoordinatorName")] Coordinators coordinators)
        {
            if (id != coordinators.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coordinators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordinatorsExists(coordinators.Id))
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
            return View(coordinators);
        }

        // GET: Coordinators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coordinators == null)
            {
                return NotFound();
            }

            var coordinators = await _context.Coordinators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinators == null)
            {
                return NotFound();
            }

            return View(coordinators);
        }

        // POST: Coordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coordinators == null)
            {
                return Problem("Entity set 'Traffic_Coordinators_Context.Coordinators'  is null.");
            }
            var coordinators = await _context.Coordinators.FindAsync(id);
            if (coordinators != null)
            {
                _context.Coordinators.Remove(coordinators);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordinatorsExists(int id)
        {
          return (_context.Coordinators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
