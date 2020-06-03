using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMonitoringSystem3.Migrations
{
    public partial class _4DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Region",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Region", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Year",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        YearNumb = table.Column<int>(nullable: false),
            //        YearName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Year", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Indicators",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        YearId = table.Column<int>(nullable: false),
            //        RegionId = table.Column<int>(nullable: false),
            //        Vrp = table.Column<double>(nullable: false),
            //        NumberOfEnterprises = table.Column<double>(nullable: false),
            //        WasteGeneration = table.Column<double>(nullable: false),
            //        ExpendituresOnEnvProt = table.Column<double>(nullable: false),
            //        TotalEmissions = table.Column<double>(nullable: false),
            //        CarbonMonoxide = table.Column<double>(nullable: false),
            //        Methane = table.Column<double>(nullable: false),
            //        NitrogenDioxide = table.Column<double>(nullable: false),
            //        NitricOxide = table.Column<double>(nullable: false),
            //        Soot = table.Column<double>(nullable: false),
            //        SulfurDioxide = table.Column<double>(nullable: false),
            //        NonMetOrgCompounds = table.Column<double>(nullable: false),
            //        CarbonDioxide = table.Column<double>(nullable: false),
            //        FromMobileSources = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Indicators", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Indicators_Region_RegionId",
            //            column: x => x.RegionId,
            //            principalTable: "Region",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Indicators_Year_YearId",
            //            column: x => x.YearId,
            //            principalTable: "Year",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Indicators_RegionId",
            //    table: "Indicators",
            //    column: "RegionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Indicators_YearId",
            //    table: "Indicators",
            //    column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
