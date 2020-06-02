using System.ComponentModel.DataAnnotations;

namespace LCMonitoringSystem3.Models
{
    public class IndicatorsModel
    {
        [Key]
        public int Id { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public double Vrp { get; set; }
        public double NumberOfEnterprises { get; set; }
        public double WasteGeneration { get; set; }
        public double ExpendituresOnEnvProt { get; set; }
        public double TotalEmissions { get; set; }
        public double CarbonMonoxide { get; set; }
        public double Methane { get; set; }
        public double NitrogenDioxide { get; set; }
        public double NitricOxide { get; set; }
        public double Soot { get; set; }
        public double SulfurDioxide { get; set; }
        public double NonMetOrgCompounds { get; set; }
        public double CarbonDioxide { get; set; }
        public double FromMobileSources { get; set; }


    }
}
