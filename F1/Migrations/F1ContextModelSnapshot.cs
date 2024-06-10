﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace F1.Migrations
{
    [DbContext(typeof(F1Context))]
    partial class F1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Pilots", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Champion")
                        .HasColumnType("bit");

                    b.Property<int>("Championships")
                        .HasColumnType("int");

                    b.Property<string>("Decade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FastLap_Rate")
                        .HasColumnType("float");

                    b.Property<int>("Fastest_Laps")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int");

                    b.Property<double>("Podium_Rate")
                        .HasColumnType("float");

                    b.Property<int>("Podiums")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<double>("Points_Per_Entry")
                        .HasColumnType("float");

                    b.Property<int>("Pole_Positions")
                        .HasColumnType("int");

                    b.Property<double>("Pole_Rate")
                        .HasColumnType("float");

                    b.Property<int>("Race_Entries")
                        .HasColumnType("int");

                    b.Property<int>("Race_Starts")
                        .HasColumnType("int");

                    b.Property<int>("Race_Wins")
                        .HasColumnType("int");

                    b.Property<double>("Start_Rate")
                        .HasColumnType("float");

                    b.Property<double>("Win_Rate")
                        .HasColumnType("float");

                    b.Property<string>("Years_Active")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("PilotsSeasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PilotId")
                        .HasColumnType("int");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.HasIndex("SeasonId");

                    b.ToTable("PilotsSeasons");
                });

            modelBuilder.Entity("Seasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Season_ChampionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Season_ChampionId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Pilots", b =>
                {
                    b.HasOne("Countries", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("PilotsSeasons", b =>
                {
                    b.HasOne("Pilots", "Pilot")
                        .WithMany("Seasons")
                        .HasForeignKey("PilotId");

                    b.HasOne("Seasons", "Season")
                        .WithMany("Pilots")
                        .HasForeignKey("SeasonId");

                    b.Navigation("Pilot");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Seasons", b =>
                {
                    b.HasOne("Pilots", "Season_Champion")
                        .WithMany()
                        .HasForeignKey("Season_ChampionId");

                    b.Navigation("Season_Champion");
                });

            modelBuilder.Entity("Pilots", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Seasons", b =>
                {
                    b.Navigation("Pilots");
                });
#pragma warning restore 612, 618
        }
    }
}
