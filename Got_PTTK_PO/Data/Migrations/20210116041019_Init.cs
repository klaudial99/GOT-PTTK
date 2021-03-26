using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObszarGorski",
                columns: table => new
                {
                    NazwaOG = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObszarGorski", x => x.NazwaOG);
                });

            migrationBuilder.CreateTable(
                name: "Punkt",
                columns: table => new
                {
                    NazwaP = table.Column<string>(maxLength: 30, nullable: false),
                    SzerGeo = table.Column<float>(maxLength: 10, nullable: false),
                    DlGeo = table.Column<float>(maxLength: 10, nullable: false),
                    Rodzaj = table.Column<int>(nullable: false),
                    WysNpm = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punkt", x => x.NazwaP);
                });

            migrationBuilder.CreateTable(
                name: "TerenGorski",
                columns: table => new
                {
                    NazwaTG = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerenGorski", x => x.NazwaTG);
                });

            migrationBuilder.CreateTable(
                name: "RegionGorski",
                columns: table => new
                {
                    IdRG = table.Column<string>(maxLength: 5, nullable: false),
                    NazwaOG1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionGorski", x => x.IdRG);
                    table.ForeignKey(
                        name: "FK_RegionGorski_ObszarGorski_NazwaOG1",
                        column: x => x.NazwaOG1,
                        principalTable: "ObszarGorski",
                        principalColumn: "NazwaOG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trasa",
                columns: table => new
                {
                    NazwaT = table.Column<string>(maxLength: 30, nullable: false),
                    NazwaPP = table.Column<string>(nullable: false),
                    NazwaPK = table.Column<string>(nullable: false),
                    LiczbaPkt = table.Column<int>(nullable: false),
                    CzyAktywna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasa", x => new { x.NazwaT, x.NazwaPP, x.NazwaPK });
                    table.ForeignKey(
                        name: "FK_Trasa_Punkt_NazwaPK",
                        column: x => x.NazwaPK,
                        principalTable: "Punkt",
                        principalColumn: "NazwaP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trasa_Punkt_NazwaPP",
                        column: x => x.NazwaPP,
                        principalTable: "Punkt",
                        principalColumn: "NazwaP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punkt_TerenGorski",
                columns: table => new
                {
                    NazwaP = table.Column<string>(nullable: false),
                    NazwaTG = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punkt_TerenGorski", x => new { x.NazwaP, x.NazwaTG });
                    table.ForeignKey(
                        name: "FK_Punkt_TerenGorski_Punkt_NazwaP",
                        column: x => x.NazwaP,
                        principalTable: "Punkt",
                        principalColumn: "NazwaP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punkt_TerenGorski_TerenGorski_NazwaTG",
                        column: x => x.NazwaTG,
                        principalTable: "TerenGorski",
                        principalColumn: "NazwaTG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punkt_RegionGorski",
                columns: table => new
                {
                    NazwaP = table.Column<string>(nullable: false),
                    IdRG = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punkt_RegionGorski", x => new { x.NazwaP, x.IdRG });
                    table.ForeignKey(
                        name: "FK_Punkt_RegionGorski_RegionGorski_IdRG",
                        column: x => x.IdRG,
                        principalTable: "RegionGorski",
                        principalColumn: "IdRG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punkt_RegionGorski_Punkt_NazwaP",
                        column: x => x.NazwaP,
                        principalTable: "Punkt",
                        principalColumn: "NazwaP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Punkt_RegionGorski_IdRG",
                table: "Punkt_RegionGorski",
                column: "IdRG");

            migrationBuilder.CreateIndex(
                name: "IX_Punkt_TerenGorski_NazwaTG",
                table: "Punkt_TerenGorski",
                column: "NazwaTG");

            migrationBuilder.CreateIndex(
                name: "IX_RegionGorski_NazwaOG1",
                table: "RegionGorski",
                column: "NazwaOG1");

            migrationBuilder.CreateIndex(
                name: "IX_Trasa_NazwaPK",
                table: "Trasa",
                column: "NazwaPK");

            migrationBuilder.CreateIndex(
                name: "IX_Trasa_NazwaPP",
                table: "Trasa",
                column: "NazwaPP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punkt_RegionGorski");

            migrationBuilder.DropTable(
                name: "Punkt_TerenGorski");

            migrationBuilder.DropTable(
                name: "Trasa");

            migrationBuilder.DropTable(
                name: "RegionGorski");

            migrationBuilder.DropTable(
                name: "TerenGorski");

            migrationBuilder.DropTable(
                name: "Punkt");

            migrationBuilder.DropTable(
                name: "ObszarGorski");
        }
    }
}
