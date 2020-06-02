﻿// <auto-generated />
using LCMonitoringSystem3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LCMonitoringSystem3.Migrations
{
    [DbContext(typeof(IndicatorsDbContext))]
    partial class IndicatorsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LCMonitoringSystem3.Models.IndicatorsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CarbonDioxide")
                        .HasColumnType("float");

                    b.Property<double>("CarbonMonoxide")
                        .HasColumnType("float");

                    b.Property<double>("ExpendituresOnEnvProt")
                        .HasColumnType("float");

                    b.Property<double>("FromMobileSources")
                        .HasColumnType("float");

                    b.Property<double>("Methane")
                        .HasColumnType("float");

                    b.Property<double>("NitricOxide")
                        .HasColumnType("float");

                    b.Property<double>("NitrogenDioxide")
                        .HasColumnType("float");

                    b.Property<double>("NonMetOrgCompounds")
                        .HasColumnType("float");

                    b.Property<double>("NumberOfEnterprises")
                        .HasColumnType("float");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<double>("Soot")
                        .HasColumnType("float");

                    b.Property<double>("SulfurDioxide")
                        .HasColumnType("float");

                    b.Property<double>("TotalEmissions")
                        .HasColumnType("float");

                    b.Property<double>("Vrp")
                        .HasColumnType("float");

                    b.Property<double>("WasteGeneration")
                        .HasColumnType("float");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("YearId");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("LCMonitoringSystem3.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("LCMonitoringSystem3.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("YearNumb")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("LCMonitoringSystem3.Models.IndicatorsModel", b =>
                {
                    b.HasOne("LCMonitoringSystem3.Models.Region", "Region")
                        .WithMany("Indicators")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LCMonitoringSystem3.Models.Year", "Year")
                        .WithMany("Indicators")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
