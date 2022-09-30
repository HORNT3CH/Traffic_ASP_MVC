using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Data;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly Traffic_Schedule_Context _context;

        public SchedulesController(Traffic_Schedule_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5000)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var theSchedule = _context.Schedule.Skip(ExcludeRecords).Take(pageSize).Where(y => y.Status != "Loaded");

            var result = new PagedResult<Schedule>
            {
                Data = await theSchedule.AsNoTracking().ToListAsync(),
                TotalItems = _context.Schedule.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);

        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewBag.Coordinator = new SelectList(_context.Coordinators.ToList().OrderBy(x => x.CoordinatorName), "CoordinatorName", "CoordinatorName");
            ViewBag.Carrier = new SelectList(_context.Carriers.ToList().OrderBy(x => x.CarrierName), "CarrierName", "CarrierName");
            ViewBag.Customer = new SelectList(_context.Customers.ToList().OrderBy(x => x.CustomerName), "CustomerName", "CustomerName");
            ViewBag.TimeSlot = new SelectList(_context.TimeSlots.ToList().OrderBy(x => x.Id), "SlotName", "SlotName");
            ViewBag.City = new SelectList(_context.Cities.ToList().OrderBy(x => x.CityName), "CityName", "CityName");
            ViewBag.State = new SelectList(_context.States.ToList().OrderBy(x => x.StateName), "StateName", "StateName");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ScheduleDate,TimeSlot,Status,Type,NumberCartons,LoadCube,MbolNbr,LoadNbr,LoaderName,CarrierName,CustomerName,CustomerCity,CustomerState,LoadComments,LoadScheduler,Location,StartTime,FinishTime,StageLocation,StageStartTime,StageFinishTime,StagerName")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Load " + schedule.MbolNbr + " Was Scheduled On " + schedule.ScheduleDate.ToShortDateString() + " At " + schedule.TimeSlot + "!";
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {                        
            ViewBag.Coordinator = new SelectList(_context.Coordinators.ToList().OrderBy(x => x.CoordinatorName), "CoordinatorName", "CoordinatorName");
            ViewBag.Carrier = new SelectList(_context.Carriers.ToList().OrderBy(x => x.CarrierName), "CarrierName", "CarrierName");
            ViewBag.Customer = new SelectList(_context.Customers.ToList().OrderBy(x => x.CustomerName), "CustomerName", "CustomerName");
            ViewBag.TimeSlot = new SelectList(_context.TimeSlots.ToList().OrderBy(x => x.Id), "SlotName", "SlotName");
            ViewBag.City = new SelectList(_context.Cities.ToList().OrderBy(x => x.CityName), "CityName", "CityName");
            ViewBag.State = new SelectList(_context.States.ToList().OrderBy(x => x.StateName), "StateName", "StateName");
            ViewBag.Doors = new SelectList(_context.Doors.ToList().Where(y => y.Status == "Open" && y.Type == "Door").OrderBy(x => x.Location), "Location", "Location");
            ViewBag.DockLot = new SelectList(_context.DockLot.ToList().Where(x => x.Status == "Empty").OrderBy(x => x.TrailerNbr), "TrailerNbr", "TrailerNbr");
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ScheduleDate,TimeSlot,Status,Type,NumberCartons,LoadCube,MbolNbr,LoadNbr,LoaderName,CarrierName,CustomerName,CustomerCity,CustomerState,LoadComments,LoadScheduler,Location,StartTime,FinishTime,TrailerNbr,StageLocation,StageStartTime,StageFinishTime,StagerName")] Schedule schedule)
        {
            if (id != schedule.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Load " + schedule.MbolNbr + " Was Updated Successfully...!";
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        public async Task<IActionResult> StageSheet(int? id)
        {

            var schedule = await _context.Schedule.FindAsync(id);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'Traffic_Schedule_Context.Schedule'  is null.");
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
          return (_context.Schedule?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
