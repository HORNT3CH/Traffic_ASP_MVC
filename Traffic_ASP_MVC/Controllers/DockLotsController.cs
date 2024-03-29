﻿using System;
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
    public class DockLotsController : Controller
    {
        private readonly Traffic_DockLot_Context _context;

        public DockLotsController(Traffic_DockLot_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=1000)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var theDockLot = _context.DockLot.Skip(ExcludeRecords).Take(pageSize);
            
            var result = new PagedResult<DockLot>
            {
                Data = await theDockLot.AsNoTracking().ToListAsync(),
                TotalItems = _context.DockLot.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        // GET: DockLots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DockLot == null)
            {
                return NotFound();
            }

            var dockLot = await _context.DockLot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dockLot == null)
            {
                return NotFound();
            }

            return View(dockLot);
        }

        // GET: DockLots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DockLots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,location,carrierName,status,trailerNbr,dimension,comments,loadNbr,mbolNbr,timeStamp")] DockLot dockLot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dockLot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dockLot);
        }

        // GET: DockLots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DockLot == null)
            {
                return NotFound();
            }

            var dockLot = await _context.DockLot.FindAsync(id);
            if (dockLot == null)
            {
                return NotFound();
            }
            return View(dockLot);
        }

        // POST: DockLots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,location,carrierName,status,trailerNbr,dimension,comments,loadNbr,mbolNbr,timeStamp")] DockLot dockLot)
        {
            if (id != dockLot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dockLot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DockLotExists(dockLot.ID))
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
            return View(dockLot);
        }

        // GET: DockLots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DockLot == null)
            {
                return NotFound();
            }

            var dockLot = await _context.DockLot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dockLot == null)
            {
                return NotFound();
            }

            return View(dockLot);
        }

        // POST: DockLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DockLot == null)
            {
                return Problem("Entity set 'Traffic_DockLot_Context.DockLot'  is null.");
            }
            var dockLot = await _context.DockLot.FindAsync(id);
            if (dockLot != null)
            {
                _context.DockLot.Remove(dockLot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DockLotExists(int id)
        {
            return (_context.DockLot?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
