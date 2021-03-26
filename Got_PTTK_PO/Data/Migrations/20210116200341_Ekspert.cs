using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class Ekspert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PotwierdzonyPrzez",
                table: "FragmentWycieczki");

            migrationBuilder.AddColumn<string>(
                name: "IdUz",
                table: "FragmentWycieczki",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Legitymacja",
                columns: table => new
                {
                    NumerL = table.Column<string>(nullable: false),
                    DataWaznosci = table.Column<DateTime>(nullable: false),
                    CzyWazna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legitymacja", x => x.NumerL);
                });

            migrationBuilder.CreateTable(
                name: "EkspertGorski",
                columns: table => new
                {
                    IdUz = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 30, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    NrTel = table.Column<string>(maxLength: 12, nullable: false),
                    NumerL = table.Column<string>(nullable: true),
                    IdA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkspertGorski", x => x.IdUz);
                    table.ForeignKey(
                        name: "FK_EkspertGorski_Adres_IdA",
                        column: x => x.IdA,
                        principalTable: "Adres",
                        principalColumn: "IdA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkspertGorski_AspNetUsers_IdUz",
                        column: x => x.IdUz,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkspertGorski_Legitymacja_NumerL",
                        column: x => x.NumerL,
                        principalTable: "Legitymacja",
                        principalColumn: "NumerL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FragmentWycieczki_IdUz",
                table: "FragmentWycieczki",
                column: "IdUz");

            migrationBuilder.CreateIndex(
                name: "IX_EkspertGorski_IdA",
                table: "EkspertGorski",
                column: "IdA");

            migrationBuilder.CreateIndex(
                name: "IX_EkspertGorski_NumerL",
                table: "EkspertGorski",
                column: "NumerL");

            migrationBuilder.AddForeignKey(
                name: "FK_FragmentWycieczki_EkspertGorski_IdUz",
                table: "FragmentWycieczki",
                column: "IdUz",
                principalTable: "EkspertGorski",
                principalColumn: "IdUz",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragmentWycieczki_EkspertGorski_IdUz",
                table: "FragmentWycieczki");

            migrationBuilder.DropTable(
                name: "EkspertGorski");

            migrationBuilder.DropTable(
                name: "Legitymacja");

            migrationBuilder.DropIndex(
                name: "IX_FragmentWycieczki_IdUz",
                table: "FragmentWycieczki");

            migrationBuilder.DropColumn(
                name: "IdUz",
                table: "FragmentWycieczki");

            migrationBuilder.AddColumn<int>(
                name: "PotwierdzonyPrzez",
                table: "FragmentWycieczki",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
