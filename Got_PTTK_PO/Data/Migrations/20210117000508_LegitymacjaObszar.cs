using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class LegitymacjaObszar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EkspertGorski_Legitymacja_NumerL",
                table: "EkspertGorski");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legitymacja",
                table: "Legitymacja");

            migrationBuilder.RenameTable(
                name: "Legitymacja",
                newName: "Legitymacje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legitymacje",
                table: "Legitymacje",
                column: "NumerL");

            migrationBuilder.CreateTable(
                name: "Legitymacja_ObszarGorski",
                columns: table => new
                {
                    NumerL = table.Column<string>(nullable: false),
                    NazwaOG = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legitymacja_ObszarGorski", x => new { x.NumerL, x.NazwaOG });
                    table.ForeignKey(
                        name: "FK_Legitymacja_ObszarGorski_ObszarGorski_NazwaOG",
                        column: x => x.NazwaOG,
                        principalTable: "ObszarGorski",
                        principalColumn: "NazwaOG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Legitymacja_ObszarGorski_Legitymacje_NumerL",
                        column: x => x.NumerL,
                        principalTable: "Legitymacje",
                        principalColumn: "NumerL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legitymacja_ObszarGorski_NazwaOG",
                table: "Legitymacja_ObszarGorski",
                column: "NazwaOG");

            migrationBuilder.AddForeignKey(
                name: "FK_EkspertGorski_Legitymacje_NumerL",
                table: "EkspertGorski",
                column: "NumerL",
                principalTable: "Legitymacje",
                principalColumn: "NumerL",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EkspertGorski_Legitymacje_NumerL",
                table: "EkspertGorski");

            migrationBuilder.DropTable(
                name: "Legitymacja_ObszarGorski");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legitymacje",
                table: "Legitymacje");

            migrationBuilder.RenameTable(
                name: "Legitymacje",
                newName: "Legitymacja");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legitymacja",
                table: "Legitymacja",
                column: "NumerL");

            migrationBuilder.AddForeignKey(
                name: "FK_EkspertGorski_Legitymacja_NumerL",
                table: "EkspertGorski",
                column: "NumerL",
                principalTable: "Legitymacja",
                principalColumn: "NumerL",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
