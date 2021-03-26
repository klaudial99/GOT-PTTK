using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class RegionyObszarySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Punkt",
                columns: new[] { "NazwaP", "DlGeo", "Rodzaj", "SzerGeo", "WysNpm" },
                values: new object[,]
                {
                    { "Pierwszy", 1f, "Początkowy", 12f, 1231f },
                    { "Drugi", 2f, "Pośredni", 122f, 1232f },
                    { "Trzeci", 3f, "Początkowy", 124f, 1233f }
                });

            migrationBuilder.InsertData(
                table: "ObszarGorski",
                columns: new[] { "NazwaOG" },
                values: new object[] { "A1" });

            migrationBuilder.InsertData(
                table: "RegionGorski",
                columns: new[] { "IdRG", "NazwaOG" },
                values: new object[] { "TEST", "A1" });

            migrationBuilder.InsertData(
                table: "Trasa",
                columns: new[] { "NazwaT", "NazwaPP", "NazwaPK", "CzyAktywna", "LiczbaPkt" },
                values: new object[] { "Pierwsza", "Pierwszy", "Trzeci", true, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Punkt",
                keyColumn: "NazwaP",
                keyValue: "Drugi");

            migrationBuilder.DeleteData(
                table: "RegionGorski",
                keyColumn: "IdRG",
                keyValue: "TEST");

            migrationBuilder.DeleteData(
                table: "Trasa",
                keyColumns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                keyValues: new object[] { "Pierwsza", "Pierwszy", "Trzeci" });

            migrationBuilder.DeleteData(
                table: "Punkt",
                keyColumn: "NazwaP",
                keyValue: "Pierwszy");

            migrationBuilder.DeleteData(
                table: "Punkt",
                keyColumn: "NazwaP",
                keyValue: "Trzeci");
        }
    }
}
