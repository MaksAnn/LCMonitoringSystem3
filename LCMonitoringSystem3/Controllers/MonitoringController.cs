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
    public class MonitoringController : Controller
    {
        private readonly IndicatorsDbContext _context;

        public MonitoringController(IndicatorsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            IQueryable<IndicatorsModel> indicators = _context.Indicators.Include(i => i.Region).Include(i => i.Year);

            string[] colms = new string[14];
            colms[0] = "ВРП";
            colms[1] = "Кп";
            colms[2] = "УВ";
            colms[3] = "Вит.ОНПС";
            colms[4] = "ЗР";
            colms[5] = "CO";
            colms[6] = "CH4";
            colms[7] = "NO2";
            colms[8] = "N2O";
            colms[9] = "Сажі";
            colms[10] = "SO2";
            colms[11] = "НМЛОС";
            colms[12] = "CO2";
            colms[13] = "Авто";

            ViewBag.cols = "abcdefghijklmnopqrstuvwxyz";


            return View(_context.Indicators);
        }
        public JsonResult GetIndicators()
        {
           
            return Json(_context.Indicators);
        }

        public IActionResult SimpleCorrel()
        {

            string[] colms = new string[14];
            colms[0] = "ВРП";
            colms[1] = "Кп";
            colms[2] = "УВ";
            colms[3] = "Вит.ОНПС";
            colms[4] = "ЗР";
            colms[5] = "CO";
            colms[6] = "CH4";
            colms[7] = "NO2";
            colms[8] = "N2O";
            colms[9] = "Сажі";
            colms[10] = "SO2";
            colms[11] = "НМЛОС";
            colms[12] = "CO2";
            colms[13] = "Авто";

            ViewBag.StrMas = colms;

            ViewBag.Str = "Varvar";
            return View();
        }

    }
}