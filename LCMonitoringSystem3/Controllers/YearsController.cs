using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LCMonitoringSystem3.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LCMonitoringSystem3.Controllers
{
    public class YearsController : Controller
    {
        private readonly IndicatorsDbContext _context;

        public YearsController(IndicatorsDbContext context)
        {
            _context = context;
        }

        // GET: Years
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Years.ToListAsync());
        }

        // GET: Years/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var year = await _context.Years
                .FirstOrDefaultAsync(m => m.Id == id);
            if (year == null)
            {
                return NotFound();
            }

            return View(year);
        }

        // GET: Years/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Years/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,YearNumb,YearName")] Year year)
        {
            if (ModelState.IsValid)
            {
                _context.Add(year);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(year);
        }

        // GET: Years/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var year = await _context.Years.FindAsync(id);
            if (year == null)
            {
                return NotFound();
            }
            return View(year);
        }

        // POST: Years/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YearNumb,YearName")] Year year)
        {
            if (id != year.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(year);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YearExists(year.Id))
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
            return View(year);
        }

        // GET: Years/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var year = await _context.Years
                .FirstOrDefaultAsync(m => m.Id == id);
            if (year == null)
            {
                return NotFound();
            }

            return View(year);
        }

        // POST: Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var year = await _context.Years.FindAsync(id);
            _context.Years.Remove(year);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YearExists(int id)
        {
            return _context.Years.Any(e => e.Id == id);
        }
    }
}
