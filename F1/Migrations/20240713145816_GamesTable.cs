using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1.Migrations
{
    /// <inheritdoc />
    public partial class GamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question1Id = table.Column<int>(type: "int", nullable: true),
                    Question2Id = table.Column<int>(type: "int", nullable: true),
                    Question3Id = table.Column<int>(type: "int", nullable: true),
                    Question4Id = table.Column<int>(type: "int", nullable: true),
                    Question5Id = table.Column<int>(type: "int", nullable: true),
                    Question6Id = table.Column<int>(type: "int", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question1Id",
                        column: x => x.Question1Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question2Id",
                        column: x => x.Question2Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question3Id",
                        column: x => x.Question3Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question4Id",
                        column: x => x.Question4Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question5Id",
                        column: x => x.Question5Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Questions_Question6Id",
                        column: x => x.Question6Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question1Id",
                table: "Games",
                column: "Question1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question2Id",
                table: "Games",
                column: "Question2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question3Id",
                table: "Games",
                column: "Question3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question4Id",
                table: "Games",
                column: "Question4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question5Id",
                table: "Games",
                column: "Question5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Question6Id",
                table: "Games",
                column: "Question6Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
