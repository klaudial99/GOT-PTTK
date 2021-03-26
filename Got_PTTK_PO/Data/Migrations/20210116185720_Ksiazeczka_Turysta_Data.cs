using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class Ksiazeczka_Turysta_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    IdA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(maxLength: 30, nullable: true),
                    NrDomu = table.Column<string>(maxLength: 5, nullable: true),
                    NrMieszkania = table.Column<string>(maxLength: 5, nullable: true),
                    KodPocztowy = table.Column<string>(maxLength: 6, nullable: true),
                    Miasto = table.Column<string>(maxLength: 30, nullable: true),
                    Kraj = table.Column<string>(maxLength: 30, nullable: true),
                    IdUz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.IdA);
                });

            migrationBuilder.CreateTable(
                name: "KsiazeczkaGOTPTTK",
                columns: table => new
                {
                    NumerK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataUtworzenia = table.Column<DateTime>(nullable: false),
                    IdUz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazeczkaGOTPTTK", x => x.NumerK);
                });

            migrationBuilder.CreateTable(
                name: "Turysta",
                columns: table => new
                {
                    IdUz = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 30, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    NrTel = table.Column<string>(maxLength: 12, nullable: true),
                    CzyDziecko = table.Column<bool>(nullable: false),
                    NumerK = table.Column<int>(nullable: false),
                    IdA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turysta", x => x.IdUz);
                    table.ForeignKey(
                        name: "FK_Turysta_Adres_IdA",
                        column: x => x.IdA,
                        principalTable: "Adres",
                        principalColumn: "IdA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turysta_AspNetUsers_IdUz",
                        column: x => x.IdUz,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                        column: x => x.NumerK,
                        principalTable: "KsiazeczkaGOTPTTK",
                        principalColumn: "NumerK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczka_NumerK",
                table: "Wycieczka",
                column: "NumerK");

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_IdA",
                table: "Turysta",
                column: "IdA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_NumerK",
                table: "Turysta",
                column: "NumerK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTK_NumerK",
                table: "Wycieczka",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTK_NumerK",
                table: "Wycieczka");

            migrationBuilder.DropTable(
                name: "Turysta");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "KsiazeczkaGOTPTTK");

            migrationBuilder.DropIndex(
                name: "IX_Wycieczka_NumerK",
                table: "Wycieczka");
        }
    }
}
