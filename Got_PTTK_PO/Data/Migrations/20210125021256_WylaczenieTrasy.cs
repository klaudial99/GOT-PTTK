using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class WylaczenieTrasy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WylaczenieTrasy",
                columns: table => new
                {
                    DataPocz = table.Column<DateTime>(nullable: false),
                    NazwaT = table.Column<string>(maxLength: 30, nullable: false),
                    NazwaPP = table.Column<string>(maxLength: 30, nullable: false),
                    NazwaPK = table.Column<string>(maxLength: 30, nullable: false),
                    DataKonc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WylaczenieTrasy", x => new { x.DataPocz, x.NazwaPP, x.NazwaPK, x.NazwaT });
                    table.ForeignKey(
                        name: "FK_WylaczenieTrasy_Trasa_NazwaT_NazwaPP_NazwaPK",
                        columns: x => new { x.NazwaT, x.NazwaPP, x.NazwaPK },
                        principalTable: "Trasa",
                        principalColumns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WylaczenieTrasy_NazwaT_NazwaPP_NazwaPK",
                table: "WylaczenieTrasy",
                columns: new[] { "NazwaT", "NazwaPP", "NazwaPK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WylaczenieTrasy");
        }
    }
}
