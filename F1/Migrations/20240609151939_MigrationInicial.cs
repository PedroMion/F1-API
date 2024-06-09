using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    Nationality_Id = table.Column<int>(type: "int", nullable: false),
                    Championships = table.Column<int>(type: "int", nullable: false),
                    Race_Entries = table.Column<int>(type: "int", nullable: false),
                    Race_Starts = table.Column<int>(type: "int", nullable: false),
                    Pole_Positions = table.Column<int>(type: "int", nullable: false),
                    Race_Wins = table.Column<int>(type: "int", nullable: false),
                    Podiums = table.Column<int>(type: "int", nullable: false),
                    Fastest_Laps = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Decade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pole_Rate = table.Column<double>(type: "float", nullable: false),
                    Start_Rate = table.Column<double>(type: "float", nullable: false),
                    Win_Rate = table.Column<double>(type: "float", nullable: false),
                    Podium_Rate = table.Column<double>(type: "float", nullable: false),
                    FastLap_Rate = table.Column<double>(type: "float", nullable: false),
                    Points_Per_Entry = table.Column<double>(type: "float", nullable: false),
                    Years_Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Champion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilots_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Decade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season_ChampionId = table.Column<int>(type: "int", nullable: true),
                    Season_Champion_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Pilots_Season_ChampionId",
                        column: x => x.Season_ChampionId,
                        principalTable: "Pilots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PilotsSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotId = table.Column<int>(type: "int", nullable: true),
                    Pilot_Id = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: true),
                    Season_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotsSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotsSeasons_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PilotsSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_NationalityId",
                table: "Pilots",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotsSeasons_PilotId",
                table: "PilotsSeasons",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotsSeasons_SeasonId",
                table: "PilotsSeasons",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_Season_ChampionId",
                table: "Seasons",
                column: "Season_ChampionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotsSeasons");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
