using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class RegionyObszary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionGorski_ObszarGorski_NazwaOG1",
                table: "RegionGorski");

            migrationBuilder.DropIndex(
                name: "IX_RegionGorski_NazwaOG1",
                table: "RegionGorski");

            migrationBuilder.DropColumn(
                name: "NazwaOG1",
                table: "RegionGorski");

            migrationBuilder.AddColumn<string>(
                name: "NazwaOG",
                table: "RegionGorski",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionGorski_NazwaOG",
                table: "RegionGorski",
                column: "NazwaOG");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionGorski_ObszarGorski_NazwaOG",
                table: "RegionGorski",
                column: "NazwaOG",
                principalTable: "ObszarGorski",
                principalColumn: "NazwaOG",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionGorski_ObszarGorski_NazwaOG",
                table: "RegionGorski");

            migrationBuilder.DropIndex(
                name: "IX_RegionGorski_NazwaOG",
                table: "RegionGorski");

            migrationBuilder.DropColumn(
                name: "NazwaOG",
                table: "RegionGorski");

            migrationBuilder.AddColumn<string>(
                name: "NazwaOG1",
                table: "RegionGorski",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionGorski_NazwaOG1",
                table: "RegionGorski",
                column: "NazwaOG1");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionGorski_ObszarGorski_NazwaOG1",
                table: "RegionGorski",
                column: "NazwaOG1",
                principalTable: "ObszarGorski",
                principalColumn: "NazwaOG",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
