using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCMonitoringSystem3.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }

        public int YearNumb { get; set; }

        public string YearName { get; set; }

        public List<IndicatorsModel> Indicators { get; set; }
        public Year()
        {
            Indicators = new List<IndicatorsModel>();
        }
    }
}
