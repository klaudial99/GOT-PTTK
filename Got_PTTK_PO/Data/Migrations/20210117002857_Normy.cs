using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class Normy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odznaka",
                columns: table => new
                {
                    IdO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(maxLength: 20, nullable: false),
                    Stopien = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odznaka", x => x.IdO);
                });

            migrationBuilder.CreateTable(
                name: "Sezon",
                columns: table => new
                {
                    IdS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerK = table.Column<int>(nullable: false),
                    Rok = table.Column<int>(nullable: false),
                    Punkty = table.Column<int>(nullable: false),
                    Nadwyzka = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezon", x => x.IdS);
                    table.ForeignKey(
                        name: "FK_Sezon_KsiazeczkaGOTPTTK_NumerK",
                        column: x => x.NumerK,
                        principalTable: "KsiazeczkaGOTPTTK",
                        principalColumn: "NumerK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Norma",
                columns: table => new
                {
                    IdO = table.Column<int>(nullable: false),
                    NumerN = table.Column<int>(nullable: false),
                    WymagPkt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norma", x => new { x.IdO, x.NumerN });
                    table.ForeignKey(
                        name: "FK_Norma_Odznaka_IdO",
                        column: x => x.IdO,
                        principalTable: "Odznaka",
                        principalColumn: "IdO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Norma_Sezon",
                columns: table => new
                {
                    IdS = table.Column<int>(nullable: false),
                    IdO = table.Column<int>(nullable: false),
                    NumerN = table.Column<int>(nullable: false),
                    Aktualna = table.Column<bool>(nullable: false),
                    Punkty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norma_Sezon", x => new { x.IdS, x.IdO, x.NumerN });
                    table.ForeignKey(
                        name: "FK_Norma_Sezon_Sezon_IdS",
                        column: x => x.IdS,
                        principalTable: "Sezon",
                        principalColumn: "IdS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Norma_Sezon_Norma_IdO_NumerN",
                        columns: x => new { x.IdO, x.NumerN },
                        principalTable: "Norma",
                        principalColumns: new[] { "IdO", "NumerN" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Norma_Sezon_IdO_NumerN",
                table: "Norma_Sezon",
                columns: new[] { "IdO", "NumerN" });

            migrationBuilder.CreateIndex(
                name: "IX_Sezon_NumerK",
                table: "Sezon",
                column: "NumerK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Norma_Sezon");

            migrationBuilder.DropTable(
                name: "Sezon");

            migrationBuilder.DropTable(
                name: "Norma");

            migrationBuilder.DropTable(
                name: "Odznaka");
        }
    }
}
