using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LCMonitoringSystem3.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Year> years, int? year, List<Region> regions, int? region)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            years.Insert(0, new Year { YearNumb = 0, YearName = "Усі", Id = 0 });
            regions.Insert(0, new Region { Name ="Усі", Id = 0 });

            Years = new SelectList(years, "Id", "YearName", year);
            Regions = new SelectList(regions, "Id", "Name", region);

            SelectedYear = year;

            SelectedRegion = region;
        }
        public SelectList Years { get; private set; }
        public SelectList Regions { get; private set; } 
        public int? SelectedYear { get; private set; }
        public int? SelectedRegion { get; private set; }

    }
}
