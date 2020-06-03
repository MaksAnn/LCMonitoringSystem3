using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMonitoringSystem3.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IndicatorsModel> Indicators { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
