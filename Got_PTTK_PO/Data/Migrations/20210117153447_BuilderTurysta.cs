using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class BuilderTurysta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta");

            migrationBuilder.DropIndex(
                name: "IX_Turysta_NumerK",
                table: "Turysta");

            migrationBuilder.AlterColumn<int>(
                name: "NumerK",
                table: "Turysta",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "IdA", "IdUz", "KodPocztowy", "Kraj", "Miasto", "NrDomu", "NrMieszkania", "Ulica" },
                values: new object[] { 1, null, "52-215", "Polska", "Wroclaw", "1", "2", "Ametystowa" });

            migrationBuilder.InsertData(
                table: "KsiazeczkaGOTPTTK",
                columns: new[] { "NumerK", "DataUtworzenia", "IdUz" },
                values: new object[] { 1, new DateTime(2020, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "832b741c-eed5-4a47-989d-cd5957355cef" });

            migrationBuilder.InsertData(
                table: "Turysta",
                columns: new[] { "IdUz", "CzyDziecko", "DataUrodzenia", "IdA", "Imie", "Nazwisko", "NrTel", "NumerK" },
                values: new object[] { "832b741c-eed5-4a47-989d-cd5957355cef", false, new DateTime(2008, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), 1, "Konrad", "Liuras", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_NumerK",
                table: "Turysta",
                column: "NumerK",
                unique: true,
                filter: "[NumerK] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta");

            migrationBuilder.DropIndex(
                name: "IX_Turysta_NumerK",
                table: "Turysta");

            migrationBuilder.DeleteData(
                table: "KsiazeczkaGOTPTTK",
                keyColumn: "NumerK",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Turysta",
                keyColumn: "IdUz",
                keyValue: "832b741c-eed5-4a47-989d-cd5957355cef");

            migrationBuilder.DeleteData(
                table: "Adres",
                keyColumn: "IdA",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "NumerK",
                table: "Turysta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_NumerK",
                table: "Turysta",
                column: "NumerK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
