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
    public class CarriersController : Controller
    {
        private readonly Traffic_Carriers_Context _context;

        public CarriersController(Traffic_Carriers_Context context)
        {
            _context = context;
        }

        // GET: Carriers
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=5000)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var theCarriers = _context.Carriers.Skip(ExcludeRecords).Take(pageSize);

            var result = new PagedResult<Carriers>
            {
                Data = await theCarriers.AsNoTracking().ToListAsync(),
                TotalItems = _context.Carriers.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carriers == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carriers == null)
            {
                return NotFound();
            }

            return View(carriers);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarrierName")] Carriers carriers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carriers);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carriers == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers.FindAsync(id);
            if (carriers == null)
            {
                return NotFound();
            }
            return View(carriers);
        }

        // POST: Carriers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarrierName")] Carriers carriers)
        {
            if (id != carriers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriersExists(carriers.Id))
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
            return View(carriers);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carriers == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carriers == null)
            {
                return NotFound();
            }

            return View(carriers);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carriers == null)
            {
                return Problem("Entity set 'Traffic_Carriers_Context.Carriers'  is null.");
            }
            var carriers = await _context.Carriers.FindAsync(id);
            if (carriers != null)
            {
                _context.Carriers.Remove(carriers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriersExists(int id)
        {
          return (_context.Carriers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
