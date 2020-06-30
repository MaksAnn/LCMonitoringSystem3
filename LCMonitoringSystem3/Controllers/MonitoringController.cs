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
using Microsoft.JSInterop;
using System.Globalization;

namespace LCMonitoringSystem3.Controllers
{

    public class MonitoringController : Controller
    {
        private readonly IndicatorsDbContext _context;

        public MonitoringController(IndicatorsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Correlation()
        {
            IQueryable<IndicatorsModel> indicators = _context.Indicators.Include(i => i.Region).Include(i => i.Year);

            int IndNamesMassSize = _context.Info.Count();
            string[] IndNamesMass = new string[IndNamesMassSize];
            int i = 0;
            foreach (IndicatorInfo n in _context.Info)
            {
                IndNamesMass[i] = n.ShortName;
                i++;
            }
            ViewBag.StrMas = IndNamesMass;

            int IndMassSize = indicators.Count();

            double[] VrpMass = new double[IndMassSize];
            double[] NumberOfEnterprisesMass = new double[IndMassSize];
            double[] WasteGenerationMass = new double[IndMassSize];
            double[] ExpendituresOnEnvProtMass = new double[IndMassSize];
            double[] TotalEmissionsMass = new double[IndMassSize];
            double[] CarbonMonoxideMass = new double[IndMassSize];
            double[] MethaneMass = new double[IndMassSize];
            double[] NitrogenDioxideMass = new double[IndMassSize];
            double[] NitricOxideMass = new double[IndMassSize];
            double[] SootMass = new double[IndMassSize];
            double[] SulfurDioxideMass = new double[IndMassSize];
            double[] NonMetOrgCompoundsMass = new double[IndMassSize];
            double[] CarbonDioxideMass = new double[IndMassSize];
            double[] FromMobileSourcesMass = new double[IndMassSize];

            int i1 = 0;
            foreach (IndicatorsModel n in indicators)
            {
                VrpMass[i1] = n.Vrp;
                NumberOfEnterprisesMass[i1] = n.NumberOfEnterprises;
                WasteGenerationMass[i1] = n.WasteGeneration;
                ExpendituresOnEnvProtMass[i1] = n.ExpendituresOnEnvProt;
                TotalEmissionsMass[i1] = n.TotalEmissions;
                CarbonMonoxideMass[i1] = n.CarbonMonoxide;
                MethaneMass[i1] = n.Methane;
                NitrogenDioxideMass[i1] = n.NitrogenDioxide;
                NitricOxideMass[i1] = n.NitricOxide;
                SootMass[i1] = n.Soot;
                SulfurDioxideMass[i1] = n.SulfurDioxide;
                NonMetOrgCompoundsMass[i1] = n.NonMetOrgCompounds;
                CarbonDioxideMass[i1] = n.CarbonDioxide;
                FromMobileSourcesMass[i1] = n.FromMobileSources;
                i1++;
            }

            ViewBag.VrpMass = VrpMass;
            ViewBag.NumberOfEnterprisesMass = NumberOfEnterprisesMass;
            ViewBag.WasteGenerationMass = WasteGenerationMass;
            ViewBag.ExpendituresOnEnvProtMass = ExpendituresOnEnvProtMass;
            ViewBag.TotalEmissionsMass = TotalEmissionsMass;
            ViewBag.CarbonMonoxideMass = CarbonMonoxideMass;
            ViewBag.MethaneMass = MethaneMass;
            ViewBag.NitrogenDioxideMass = NitrogenDioxideMass;
            ViewBag.NitricOxideMass = NitricOxideMass;
            ViewBag.SootMass = SootMass;
            ViewBag.SulfurDioxideMass = SulfurDioxideMass;
            ViewBag.NonMetOrgCompoundsMass = NonMetOrgCompoundsMass;
            ViewBag.CarbonDioxideMass = CarbonDioxideMass;
            ViewBag.FromMobileSourcesMass = FromMobileSourcesMass;

            return View(indicators);
        }


        public IActionResult RegionStat(int? region = 1)
        {
            //Фильтрация
            IQueryable<IndicatorsModel> indicators = _context.Indicators.Include(i => i.Region).Include(i => i.Year);

            if (region != null && region != 0)
            {
                indicators = indicators.Where(p => p.RegionId == region);
            }
            indicators = indicators.OrderBy(s => s.Year.YearNumb);

            List<Region> regions = _context.Regions.ToList();
            List<Year> years = _context.Years.ToList();

            ChartFilterViewModel viewModel = new ChartFilterViewModel
            {
                Indicators = indicators.ToList(),
                Regions = new SelectList(regions, "Id", "Name"),
                Years = new SelectList(years, "Id", "YearName")
            };

            int IndMassSize = indicators.Count();

            string[] YearsMass = new string[IndMassSize];

            double[] VrpMass = new double[IndMassSize];
            double[] NumberOfEnterprisesMass = new double[IndMassSize];
            double[] WasteGenerationMass = new double[IndMassSize];
            double[] ExpendituresOnEnvProtMass = new double[IndMassSize];
            double[] TotalEmissionsMass = new double[IndMassSize];
            double[] CarbonMonoxideMass = new double[IndMassSize];
            double[] MethaneMass = new double[IndMassSize];
            double[] NitrogenDioxideMass = new double[IndMassSize];
            double[] NitricOxideMass = new double[IndMassSize];
            double[] SootMass = new double[IndMassSize];
            double[] SulfurDioxideMass = new double[IndMassSize];
            double[] NonMetOrgCompoundsMass = new double[IndMassSize];
            double[] CarbonDioxideMass = new double[IndMassSize];
            double[] FromMobileSourcesMass = new double[IndMassSize];


            int i1 = 0;
            foreach (IndicatorsModel n in indicators)
            {
                YearsMass[i1] = n.Year.YearNumb.ToString();
                VrpMass[i1] = n.Vrp;
                NumberOfEnterprisesMass[i1] = n.NumberOfEnterprises;
                WasteGenerationMass[i1] = n.WasteGeneration;
                ExpendituresOnEnvProtMass[i1] = n.ExpendituresOnEnvProt;
                TotalEmissionsMass[i1] = n.TotalEmissions;
                CarbonMonoxideMass[i1] = n.CarbonMonoxide;
                MethaneMass[i1] = n.Methane;
                NitrogenDioxideMass[i1] = n.NitrogenDioxide;
                NitricOxideMass[i1] = n.NitricOxide;
                SootMass[i1] = n.Soot;
                SulfurDioxideMass[i1] = n.SulfurDioxide;
                NonMetOrgCompoundsMass[i1] = n.NonMetOrgCompounds;
                CarbonDioxideMass[i1] = n.CarbonDioxide;
                FromMobileSourcesMass[i1] = n.FromMobileSources;
                i1++;
            }
            ViewBag.YearsMass = YearsMass;

            ViewBag.VrpMass = VrpMass;
            ViewBag.NumberOfEnterprisesMass = NumberOfEnterprisesMass;
            ViewBag.WasteGenerationMass = WasteGenerationMass;
            ViewBag.ExpendituresOnEnvProtMass = ExpendituresOnEnvProtMass;

            ViewBag.TotalEmissionsMass = TotalEmissionsMass;

            ViewBag.CarbonMonoxideMass = CarbonMonoxideMass;
            ViewBag.MethaneMass = MethaneMass;
            ViewBag.NitrogenDioxideMass = NitrogenDioxideMass;
            ViewBag.NitricOxideMass = NitricOxideMass;
            ViewBag.SootMass = SootMass;
            ViewBag.SulfurDioxideMass = SulfurDioxideMass;
            ViewBag.NonMetOrgCompoundsMass = NonMetOrgCompoundsMass;

            ViewBag.CarbonDioxideMass = CarbonDioxideMass;
            ViewBag.FromMobileSourcesMass = FromMobileSourcesMass;



            Region Reg = _context.Regions.FirstOrDefault(p => p.Id == region);
            ViewBag.Region = Reg.Name; 


            


            return View(viewModel);
        }

        public IActionResult YearsStat(int? year = 2)
        {
            //Фильтрация
            IQueryable<IndicatorsModel> indicators = _context.Indicators.Include(i => i.Region).Include(i => i.Year);

            if (year != null && year != 0)
            {
                indicators = indicators.Where(p => p.YearId == year);
            }
            //indicators = indicators.OrderBy(s => s.Year.YearNumb);

            List<Region> regions = _context.Regions.ToList();
            List<Year> years = _context.Years.ToList();

            ChartFilterViewModel viewModel = new ChartFilterViewModel
            {
                Indicators = indicators.ToList(),
                Regions = new SelectList(regions, "Id", "Name"),
                Years = new SelectList(years, "Id", "YearName")
            };

            int IndMassSize = indicators.Count() - 1;

            string[] RegionMass = new string[IndMassSize];

            double[] VrpMass = new double[IndMassSize];
            double[] NumberOfEnterprisesMass = new double[IndMassSize];
            double[] WasteGenerationMass = new double[IndMassSize];
            double[] ExpendituresOnEnvProtMass = new double[IndMassSize];
            double[] TotalEmissionsMass = new double[IndMassSize];
            double[] CarbonMonoxideMass = new double[IndMassSize];
            double[] MethaneMass = new double[IndMassSize];
            double[] NitrogenDioxideMass = new double[IndMassSize];
            double[] NitricOxideMass = new double[IndMassSize];
            double[] SootMass = new double[IndMassSize];
            double[] SulfurDioxideMass = new double[IndMassSize];
            double[] NonMetOrgCompoundsMass = new double[IndMassSize];
            double[] CarbonDioxideMass = new double[IndMassSize];
            double[] FromMobileSourcesMass = new double[IndMassSize];


            int i1 = 0;
            foreach (IndicatorsModel n in indicators)
            {
                if (n.Region.Name != "Україна")
                {
                    RegionMass[i1] = n.Region.Name;
                    VrpMass[i1] = n.Vrp;
                    NumberOfEnterprisesMass[i1] = n.NumberOfEnterprises;
                    WasteGenerationMass[i1] = n.WasteGeneration;
                    ExpendituresOnEnvProtMass[i1] = n.ExpendituresOnEnvProt;
                    TotalEmissionsMass[i1] = n.TotalEmissions;
                    CarbonMonoxideMass[i1] = n.CarbonMonoxide;
                    MethaneMass[i1] = n.Methane;
                    NitrogenDioxideMass[i1] = n.NitrogenDioxide;
                    NitricOxideMass[i1] = n.NitricOxide;
                    SootMass[i1] = n.Soot;
                    SulfurDioxideMass[i1] = n.SulfurDioxide;
                    NonMetOrgCompoundsMass[i1] = n.NonMetOrgCompounds;
                    CarbonDioxideMass[i1] = n.CarbonDioxide;
                    FromMobileSourcesMass[i1] = n.FromMobileSources;
                    i1++;
                }
            }
            ViewBag.RegionMass = RegionMass;

            ViewBag.VrpMass = VrpMass;
            ViewBag.NumberOfEnterprisesMass = NumberOfEnterprisesMass;
            ViewBag.WasteGenerationMass = WasteGenerationMass;
            ViewBag.ExpendituresOnEnvProtMass = ExpendituresOnEnvProtMass;

            ViewBag.TotalEmissionsMass = TotalEmissionsMass;

            ViewBag.CarbonMonoxideMass = CarbonMonoxideMass;
            ViewBag.MethaneMass = MethaneMass;
            ViewBag.NitrogenDioxideMass = NitrogenDioxideMass;
            ViewBag.NitricOxideMass = NitricOxideMass;
            ViewBag.SootMass = SootMass;
            ViewBag.SulfurDioxideMass = SulfurDioxideMass;
            ViewBag.NonMetOrgCompoundsMass = NonMetOrgCompoundsMass;

            ViewBag.CarbonDioxideMass = CarbonDioxideMass;
            ViewBag.FromMobileSourcesMass = FromMobileSourcesMass;



            Year Y = _context.Years.FirstOrDefault(p => p.Id == year);
            ViewBag.Year = Y.YearName;





            return View(viewModel);
        }


        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> InfoSource()
        {
            return View(await _context.Info.ToListAsync());
        }



    }
}