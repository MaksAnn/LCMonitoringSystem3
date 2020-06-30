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
    public class IndicatorInfoesController : Controller
    {
        private readonly IndicatorsDbContext _context;

        public IndicatorInfoesController(IndicatorsDbContext context)
        {
            _context = context;
        }

        // GET: IndicatorInfoes
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Info.ToListAsync());
        }

        // GET: IndicatorInfoes/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorInfo = await _context.Info
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicatorInfo == null)
            {
                return NotFound();
            }

            return View(indicatorInfo);
        }

        // GET: IndicatorInfoes/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndicatorInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,FullName,ShortName,Unit")] IndicatorInfo indicatorInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicatorInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indicatorInfo);
        }

        // GET: IndicatorInfoes/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorInfo = await _context.Info.FindAsync(id);
            if (indicatorInfo == null)
            {
                return NotFound();
            }
            return View(indicatorInfo);
        }

        // POST: IndicatorInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ShortName,Unit")] IndicatorInfo indicatorInfo)
        {
            if (id != indicatorInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicatorInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicatorInfoExists(indicatorInfo.Id))
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
            return View(indicatorInfo);
        }

        // GET: IndicatorInfoes/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorInfo = await _context.Info
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicatorInfo == null)
            {
                return NotFound();
            }

            return View(indicatorInfo);
        }

        // POST: IndicatorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indicatorInfo = await _context.Info.FindAsync(id);
            _context.Info.Remove(indicatorInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicatorInfoExists(int id)
        {
            return _context.Info.Any(e => e.Id == id);
        }
    }
}
