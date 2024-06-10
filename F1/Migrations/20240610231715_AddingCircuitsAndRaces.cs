using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1.Migrations
{
    /// <inheritdoc />
    public partial class AddingCircuitsAndRaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FastLap_Rate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "Podium_Rate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "Start_Rate",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "Win_Rate",
                table: "Pilots");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race_Starts = table.Column<int>(type: "int", nullable: false),
                    Race_Wins = table.Column<int>(type: "int", nullable: false),
                    Constructors_Championships = table.Column<int>(type: "int", nullable: false),
                    Pilots_Championships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PilotsTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotsTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotsTeams_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PilotsTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PilotsTeams_PilotId",
                table: "PilotsTeams",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotsTeams_TeamId",
                table: "PilotsTeams",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotsTeams");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.AddColumn<double>(
                name: "FastLap_Rate",
                table: "Pilots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Podium_Rate",
                table: "Pilots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Start_Rate",
                table: "Pilots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Win_Rate",
                table: "Pilots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
