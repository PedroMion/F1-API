﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace F1.Migrations
{
    [DbContext(typeof(F1Context))]
    [Migration("20240621220055_Questions")]
    partial class Questions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Circuits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Circuits");
                });

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

                    b.Property<bool>("F2_Champion")
                        .HasColumnType("bit");

                    b.Property<int>("Fastest_Laps")
                        .HasColumnType("int");

                    b.Property<bool>("Grand_Chelem")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("PilotsTeams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PilotId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.HasIndex("TeamId");

                    b.ToTable("PilotsTeams");
                });

            modelBuilder.Entity("Races", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CircuitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int?>("Winner_PilotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CircuitId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("Winner_PilotId");

                    b.ToTable("Races");
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

            modelBuilder.Entity("Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Constructors_Championships")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pilots_Championships")
                        .HasColumnType("int");

                    b.Property<int>("Race_Starts")
                        .HasColumnType("int");

                    b.Property<int>("Race_Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Circuits", b =>
                {
                    b.HasOne("Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
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

            modelBuilder.Entity("PilotsTeams", b =>
                {
                    b.HasOne("Pilots", "Pilot")
                        .WithMany("Teams")
                        .HasForeignKey("PilotId");

                    b.HasOne("Teams", "Team")
                        .WithMany("Pilots")
                        .HasForeignKey("TeamId");

                    b.Navigation("Pilot");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Races", b =>
                {
                    b.HasOne("Circuits", "Circuit")
                        .WithMany()
                        .HasForeignKey("CircuitId");

                    b.HasOne("Seasons", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.HasOne("Pilots", "Winner_Pilot")
                        .WithMany()
                        .HasForeignKey("Winner_PilotId");

                    b.Navigation("Circuit");

                    b.Navigation("Season");

                    b.Navigation("Winner_Pilot");
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

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Seasons", b =>
                {
                    b.Navigation("Pilots");
                });

            modelBuilder.Entity("Teams", b =>
                {
                    b.Navigation("Pilots");
                });
#pragma warning restore 612, 618
        }
    }
}
