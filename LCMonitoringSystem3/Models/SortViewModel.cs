using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMonitoringSystem3.Models
{
    public class SortViewModel
    {
        public SortState YearSort { get; private set; }
        public SortState RegionSort { get; private set; }
        public SortState VrpSort { get; private set; }
        public SortState NumberOfEnterprisesSort { get; private set; }
        public SortState WasteGenerationSort { get; private set; }
        public SortState ExpendituresOnEnvProtSort { get; private set; }
        public SortState TotalEmissionsSort { get; private set; }
        public SortState CarbonMonoxideSort { get; private set; }
        public SortState MethaneSort { get; private set; }
        public SortState NitrogenDioxideSort { get; private set; }
        public SortState NitricOxideSort { get; private set; }
        public SortState SootSort { get; private set; }
        public SortState SulfurDioxideSort { get; private set; }
        public SortState NonMetOrgCompoundsSort { get; private set; }
        public SortState CarbonDioxideSort { get; private set; }
        public SortState FromMobileSourcesSort { get; private set; }

        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            YearSort = sortOrder == SortState.YearAsc ? SortState.YearDesc : SortState.YearAsc;
            RegionSort = sortOrder == SortState.RegionAsc ? SortState.RegionDesc : SortState.RegionAsc;
            VrpSort = sortOrder == SortState.VrpAsc ? SortState.VrpDesc : SortState.VrpAsc;
            NumberOfEnterprisesSort = sortOrder == SortState.NumberOfEnterprisesAsc ? SortState.NumberOfEnterprisesDesc : SortState.NumberOfEnterprisesAsc;
            WasteGenerationSort = sortOrder == SortState.WasteGenerationAsc ? SortState.WasteGenerationDesc : SortState.WasteGenerationAsc;
            ExpendituresOnEnvProtSort = sortOrder == SortState.ExpendituresOnEnvProtAsc ? SortState.ExpendituresOnEnvProtDesc : SortState.ExpendituresOnEnvProtAsc;
            TotalEmissionsSort = sortOrder == SortState.TotalEmissionsAsc ? SortState.TotalEmissionsDesc : SortState.TotalEmissionsAsc;
            CarbonMonoxideSort = sortOrder == SortState.CarbonMonoxideAsc ? SortState.CarbonMonoxideDesc : SortState.CarbonMonoxideAsc;
            MethaneSort = sortOrder == SortState.MethaneAsc ? SortState.MethaneDesc : SortState.MethaneAsc;
            NitrogenDioxideSort = sortOrder == SortState.NitrogenDioxideAsc ? SortState.NitrogenDioxideDesc : SortState.NitrogenDioxideAsc;
            NitricOxideSort = sortOrder == SortState.NitricOxideAsc ? SortState.NitricOxideDesc : SortState.NitricOxideAsc;
            SootSort = sortOrder == SortState.SootAsc ? SortState.SootDesc : SortState.SootAsc;
            SulfurDioxideSort = sortOrder == SortState.SulfurDioxideAsc ? SortState.SulfurDioxideDesc : SortState.SulfurDioxideAsc;
            NonMetOrgCompoundsSort = sortOrder == SortState.NonMetOrgCompoundsAsc ? SortState.NonMetOrgCompoundsDesc : SortState.NonMetOrgCompoundsAsc;
            CarbonDioxideSort = sortOrder == SortState.CarbonDioxideAsc ? SortState.CarbonDioxideDesc : SortState.CarbonDioxideAsc;
            FromMobileSourcesSort = sortOrder == SortState.FromMobileSourcesAsc ? SortState.FromMobileSourcesDesc : SortState.FromMobileSourcesAsc;
            Current = sortOrder;
        }
    }
}
