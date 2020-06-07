using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LCMonitoringSystem3.Models
{
    public class ChartFilterViewModel
    {
        public IEnumerable<IndicatorsModel> Indicators { get; set; }
        public SelectList Years { get; set; }
        public SelectList Regions { get; set; }
      
    }
}
