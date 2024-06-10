using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1.Migrations
{
    /// <inheritdoc />
    public partial class FixingWrongColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season_Champion_Id",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Pilot_Id",
                table: "PilotsSeasons");

            migrationBuilder.DropColumn(
                name: "Season_Id",
                table: "PilotsSeasons");

            migrationBuilder.DropColumn(
                name: "Nationality_Id",
                table: "Pilots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Season_Champion_Id",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pilot_Id",
                table: "PilotsSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Season_Id",
                table: "PilotsSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nationality_Id",
                table: "Pilots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
