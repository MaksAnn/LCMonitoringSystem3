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
    public class IndicatorsController : Controller
    {
        private readonly IndicatorsDbContext _context;

        public IndicatorsController(IndicatorsDbContext context)
        {
            _context = context;
        }

        // GET: Indicators
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var indicatorsDbContext = _context.Indicators.Include(i => i.Region).Include(i => i.Year);
            return View(await indicatorsDbContext.ToListAsync());
        }

        // GET: Indicators/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorsModel = await _context.Indicators
                .Include(i => i.Region)
                .Include(i => i.Year)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicatorsModel == null)
            {
                return NotFound();
            }

            return View(indicatorsModel);
        }

        // GET: Indicators/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["RegionName"] = new SelectList(_context.Region, "Id", "Name");
            ViewData["YearNumb"] = new SelectList(_context.Year, "Id", "YearNumb");
            return View();
        }

        // POST: Indicators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,YearId,RegionId,Vrp,NumberOfEnterprises,WasteGeneration,ExpendituresOnEnvProt,TotalEmissions,CarbonMonoxide,Methane,NitrogenDioxide,NitricOxide,Soot,SulfurDioxide,NonMetOrgCompounds,CarbonDioxide,FromMobileSources")] IndicatorsModel indicatorsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicatorsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Id", indicatorsModel.RegionId);
            ViewData["YearId"] = new SelectList(_context.Year, "Id", "Id", indicatorsModel.YearId);
            return View(indicatorsModel);
        }

        // GET: Indicators/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorsModel = await _context.Indicators.FindAsync(id);
            if (indicatorsModel == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Id", indicatorsModel.RegionId);
            ViewData["YearId"] = new SelectList(_context.Year, "Id", "Id", indicatorsModel.YearId);
            return View(indicatorsModel);
        }

        // POST: Indicators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YearId,RegionId,Vrp,NumberOfEnterprises,WasteGeneration,ExpendituresOnEnvProt,TotalEmissions,CarbonMonoxide,Methane,NitrogenDioxide,NitricOxide,Soot,SulfurDioxide,NonMetOrgCompounds,CarbonDioxide,FromMobileSources")] IndicatorsModel indicatorsModel)
        {
            if (id != indicatorsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicatorsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicatorsModelExists(indicatorsModel.Id))
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
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Id", indicatorsModel.RegionId);
            ViewData["YearId"] = new SelectList(_context.Year, "Id", "Id", indicatorsModel.YearId);
            return View(indicatorsModel);
        }

        // GET: Indicators/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicatorsModel = await _context.Indicators
                .Include(i => i.Region)
                .Include(i => i.Year)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicatorsModel == null)
            {
                return NotFound();
            }

            return View(indicatorsModel);
        }

        // POST: Indicators/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indicatorsModel = await _context.Indicators.FindAsync(id);
            _context.Indicators.Remove(indicatorsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicatorsModelExists(int id)
        {
            return _context.Indicators.Any(e => e.Id == id);
        }
    }
}
