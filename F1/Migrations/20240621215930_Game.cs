using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1.Migrations
{
    /// <inheritdoc />
    public partial class Game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "F2_Champion",
                table: "Pilots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Grand_Chelem",
                table: "Pilots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F2_Champion",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "Grand_Chelem",
                table: "Pilots");
        }
    }
}
