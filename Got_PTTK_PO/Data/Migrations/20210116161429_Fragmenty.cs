using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class Fragmenty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wycieczka",
                columns: table => new
                {
                    IdW = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerK = table.Column<int>(nullable: false),
                    DataRozp = table.Column<DateTime>(nullable: false),
                    DataZak = table.Column<DateTime>(nullable: false),
                    CzyZaliczona = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycieczka", x => x.IdW);
                });

            migrationBuilder.CreateTable(
                name: "FragmentWycieczki",
                columns: table => new
                {
                    NumerFW = table.Column<int>(nullable: false),
                    IdW = table.Column<int>(nullable: false),
                    NazwaT = table.Column<string>(maxLength: 30, nullable: false),
                    NazwaPP = table.Column<string>(nullable: true),
                    NazwaPK = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    PotwierdzonyPrzez = table.Column<int>(nullable: false),
                    CzyZaliczony = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragmentWycieczki", x => new { x.IdW, x.NumerFW });
                    table.ForeignKey(
                        name: "FK_FragmentWycieczki_Wycieczka_IdW",
                        column: x => x.IdW,
                        principalTable: "Wycieczka",
                        principalColumn: "IdW",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FragmentWycieczki_Trasa_NazwaT_NazwaPP_NazwaPK",
                        columns: x => new { x.NazwaT, x.NazwaPP, x.NazwaPK },
                        principalTable: "Trasa",
                        principalColumns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FragmentWycieczki_NazwaT_NazwaPP_NazwaPK",
                table: "FragmentWycieczki",
                columns: new[] { "NazwaT", "NazwaPP", "NazwaPK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragmentWycieczki");

            migrationBuilder.DropTable(
                name: "Wycieczka");
        }
    }
}
