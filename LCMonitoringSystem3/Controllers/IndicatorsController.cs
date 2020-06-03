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
        public async Task<IActionResult> Index(int? year, int? region, int page = 1, SortState sortOrder = SortState.YearDesc)
        {
            int pageSize = 3;

            //Фильтрация
            IQueryable<IndicatorsModel> indicators = _context.Indicators.Include(i => i.Region).Include(i => i.Year);
            if (year != null && year != 0)
            {
                indicators = indicators.Where(p => p.YearId == year);
            }
            if (region != null && region != 0)
            {
                indicators = indicators.Where(p => p.RegionId == region);
            }

            //Сортировка
            switch (sortOrder)
            {
                case SortState.YearAsc:
                    indicators = indicators.OrderBy(s => s.Year.YearNumb);
                    break;
                case SortState.RegionAsc:
                    indicators = indicators.OrderBy(s => s.Region.Name);
                    break;
                case SortState.VrpAsc:
                    indicators = indicators.OrderBy(s => s.Vrp);
                    break;
                case SortState.NumberOfEnterprisesAsc:
                    indicators = indicators.OrderBy(s => s.NumberOfEnterprises);
                    break;
                case SortState.WasteGenerationAsc:
                    indicators = indicators.OrderBy(s => s.WasteGeneration);
                    break;
                case SortState.ExpendituresOnEnvProtAsc:
                    indicators = indicators.OrderBy(s => s.ExpendituresOnEnvProt);
                    break;
                case SortState.TotalEmissionsAsc:
                    indicators = indicators.OrderBy(s => s.TotalEmissions);
                    break;
                case SortState.CarbonMonoxideAsc:
                    indicators = indicators.OrderBy(s => s.CarbonMonoxide);
                    break;
                case SortState.MethaneAsc:
                    indicators = indicators.OrderBy(s => s.Methane);
                    break;
                case SortState.NitrogenDioxideAsc:
                    indicators = indicators.OrderBy(s => s.NitrogenDioxide);
                    break;
                case SortState.NitricOxideAsc:
                    indicators = indicators.OrderBy(s => s.NitricOxide);
                    break;
                case SortState.SootAsc:
                    indicators = indicators.OrderBy(s => s.Soot);
                    break;
                case SortState.SulfurDioxideAsc:
                    indicators = indicators.OrderBy(s => s.SulfurDioxide);
                    break;
                case SortState.NonMetOrgCompoundsAsc:
                    indicators = indicators.OrderBy(s => s.NonMetOrgCompounds);
                    break;
                case SortState.CarbonDioxideAsc:
                    indicators = indicators.OrderBy(s => s.CarbonDioxide);
                    break;
                case SortState.FromMobileSourcesAsc:
                    indicators = indicators.OrderBy(s => s.FromMobileSources);
                    break;

                case SortState.RegionDesc:
                    indicators = indicators.OrderByDescending(s => s.Region.Name);
                    break;
                case SortState.VrpDesc:
                    indicators = indicators.OrderByDescending(s => s.Vrp);
                    break;
                case SortState.NumberOfEnterprisesDesc:
                    indicators = indicators.OrderByDescending(s => s.NumberOfEnterprises);
                    break;
                case SortState.WasteGenerationDesc:
                    indicators = indicators.OrderByDescending(s => s.WasteGeneration);
                    break;
                case SortState.ExpendituresOnEnvProtDesc:
                    indicators = indicators.OrderByDescending(s => s.ExpendituresOnEnvProt);
                    break;
                case SortState.TotalEmissionsDesc:
                    indicators = indicators.OrderByDescending(s => s.TotalEmissions);
                    break;
                case SortState.CarbonMonoxideDesc:
                    indicators = indicators.OrderByDescending(s => s.CarbonMonoxide);
                    break;
                case SortState.MethaneDesc:
                    indicators = indicators.OrderByDescending(s => s.Methane);
                    break;
                case SortState.NitrogenDioxideDesc:
                    indicators = indicators.OrderByDescending(s => s.NitrogenDioxide);
                    break;
                case SortState.NitricOxideDesc:
                    indicators = indicators.OrderByDescending(s => s.NitricOxide);
                    break;
                case SortState.SootDesc:
                    indicators = indicators.OrderByDescending(s => s.Soot);
                    break;
                case SortState.SulfurDioxideDesc:
                    indicators = indicators.OrderByDescending(s => s.SulfurDioxide);
                    break;
                case SortState.NonMetOrgCompoundsDesc:
                    indicators = indicators.OrderByDescending(s => s.NonMetOrgCompounds);
                    break;
                case SortState.CarbonDioxideDesc:
                    indicators = indicators.OrderByDescending(s => s.CarbonDioxide);
                    break;
                case SortState.FromMobileSourcesDesc:
                    indicators = indicators.OrderByDescending(s => s.FromMobileSources);
                    break;

                default:
                    indicators = indicators.OrderByDescending(s => s.Year.YearNumb);
                    break;
            }

            //Пагинация
            var count = await indicators.CountAsync();
            var items = await indicators.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Years.ToList(), year, _context.Regions.ToList(), region),
                Indicators = items
            };


            return View(viewModel);
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
            ViewData["RegionName"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["YearNumb"] = new SelectList(_context.Years, "Id", "YearNumb");
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
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", indicatorsModel.RegionId);
            ViewData["YearId"] = new SelectList(_context.Years, "Id", "Id", indicatorsModel.YearId);
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
            ViewData["RegionName"] = new SelectList(_context.Regions, "Id", "Name");
            ViewData["YearNumb"] = new SelectList(_context.Years, "Id", "YearNumb");
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
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", indicatorsModel.RegionId);
            ViewData["YearId"] = new SelectList(_context.Years, "Id", "Id", indicatorsModel.YearId);
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
