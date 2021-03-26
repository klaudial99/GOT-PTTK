using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class AddTourists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EkspertGorski_Adres_IdA",
                table: "EkspertGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_EkspertGorski_AspNetUsers_IdUz",
                table: "EkspertGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_EkspertGorski_Legitymacje_NumerL",
                table: "EkspertGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_FragmentWycieczki_EkspertGorski_IdUz",
                table: "FragmentWycieczki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sezon_KsiazeczkaGOTPTTK_NumerK",
                table: "Sezon");

            migrationBuilder.DropForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta");

            migrationBuilder.DropForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTK_NumerK",
                table: "Wycieczka");

            migrationBuilder.DropIndex(
                name: "IX_Turysta_IdA",
                table: "Turysta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsiazeczkaGOTPTTK",
                table: "KsiazeczkaGOTPTTK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EkspertGorski",
                table: "EkspertGorski");

            migrationBuilder.DropColumn(
                name: "IdUz",
                table: "Adres");

            migrationBuilder.RenameTable(
                name: "KsiazeczkaGOTPTTK",
                newName: "KsiazeczkaGOTPTTKs");

            migrationBuilder.RenameTable(
                name: "EkspertGorski",
                newName: "EksperciGorski");

            migrationBuilder.RenameIndex(
                name: "IX_EkspertGorski_NumerL",
                table: "EksperciGorski",
                newName: "IX_EksperciGorski_NumerL");

            migrationBuilder.RenameIndex(
                name: "IX_EkspertGorski_IdA",
                table: "EksperciGorski",
                newName: "IX_EksperciGorski_IdA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsiazeczkaGOTPTTKs",
                table: "KsiazeczkaGOTPTTKs",
                column: "NumerK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EksperciGorski",
                table: "EksperciGorski",
                column: "IdUz");

            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "IdA", "KodPocztowy", "Kraj", "Miasto", "NrDomu", "NrMieszkania", "Ulica" },
                values: new object[,]
                {
                    { 2, "57-215", "Polska", "Wałbrzych", "3c", "2a", "Brzegowa" },
                    { 3, "58-298", "Polska", "Wałbrzych", "12", "4", "Brzegowa" }
                });

            migrationBuilder.InsertData(
                table: "KsiazeczkaGOTPTTKs",
                columns: new[] { "NumerK", "DataUtworzenia", "IdUz" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "24412758-bf78-4b21-a421-cf1b349683f1" },
                    { 3, new DateTime(2020, 10, 1, 17, 7, 3, 0, DateTimeKind.Unspecified), "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d" },
                    { 4, new DateTime(2020, 12, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), "c9f02a8f-e780-4f08-b99d-41996e763671" }
                });

            migrationBuilder.InsertData(
                table: "Legitymacje",
                columns: new[] { "NumerL", "CzyWazna", "DataWaznosci" },
                values: new object[,]
                {
                    { "1111", true, new DateTime(2022, 12, 8, 9, 27, 0, 0, DateTimeKind.Unspecified) },
                    { "2222", false, new DateTime(2019, 12, 8, 9, 27, 0, 0, DateTimeKind.Unspecified) },
                    { "1111p", true, new DateTime(2022, 9, 2, 9, 27, 0, 0, DateTimeKind.Unspecified) },
                    { "2222p", false, new DateTime(2021, 1, 8, 9, 27, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EksperciGorski",
                columns: new[] { "IdUz", "DataUrodzenia", "IdA", "Imie", "Nazwisko", "NrTel", "NumerL" },
                values: new object[,]
                {
                    { "f97cf24a-826f-4bb7-86dc-fb3dd75db49e", new DateTime(1962, 1, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), 2, "Przodownik1", "Kowalski", "696380122", "1111" },
                    { "672e4d89-8a65-4171-a757-60a0271a2148", new DateTime(1962, 1, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), 3, "Przodownik2", "Kowalski", "111234432", "2222" },
                    { "c5186eea-0e69-4523-96e3-e69841245e5a", new DateTime(1962, 1, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), 2, "Przewodnik1", "Nowak1", "501380756", "1111p" },
                    { "22923dfe-c5a2-4f8c-8d5c-dbc8de208b38", new DateTime(1962, 1, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), 1, "Przewodnik2", "Kowalski2", "123423123", "2222p" }
                });

            migrationBuilder.InsertData(
                table: "Legitymacja_ObszarGorski",
                columns: new[] { "NumerL", "NazwaOG" },
                values: new object[,]
                {
                    { "1111", "A1" },
                    { "1111", "C3" },
                    { "2222", "C3" },
                    { "2222", "A2" },
                    { "1111p", "C3" }
                });

            migrationBuilder.InsertData(
                table: "Turysta",
                columns: new[] { "IdUz", "CzyDziecko", "DataUrodzenia", "IdA", "Imie", "Nazwisko", "NrTel", "NumerK" },
                values: new object[,]
                {
                    { "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d", false, new DateTime(1995, 4, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), 2, "Turysta2", "NazwiskoTurysty2", null, null },
                    { "24412758-bf78-4b21-a421-cf1b349683f1", false, new DateTime(1986, 3, 3, 7, 47, 0, 0, DateTimeKind.Unspecified), 3, "Turysta1", "NazwiskoTurysty1", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_IdA",
                table: "Turysta",
                column: "IdA");

            migrationBuilder.AddForeignKey(
                name: "FK_EksperciGorski_Adres_IdA",
                table: "EksperciGorski",
                column: "IdA",
                principalTable: "Adres",
                principalColumn: "IdA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EksperciGorski_AspNetUsers_IdUz",
                table: "EksperciGorski",
                column: "IdUz",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EksperciGorski_Legitymacje_NumerL",
                table: "EksperciGorski",
                column: "NumerL",
                principalTable: "Legitymacje",
                principalColumn: "NumerL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FragmentWycieczki_EksperciGorski_IdUz",
                table: "FragmentWycieczki",
                column: "IdUz",
                principalTable: "EksperciGorski",
                principalColumn: "IdUz",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sezon_KsiazeczkaGOTPTTKs_NumerK",
                table: "Sezon",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTKs",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTKs_NumerK",
                table: "Turysta",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTKs",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTKs_NumerK",
                table: "Wycieczka",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTKs",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EksperciGorski_Adres_IdA",
                table: "EksperciGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_EksperciGorski_AspNetUsers_IdUz",
                table: "EksperciGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_EksperciGorski_Legitymacje_NumerL",
                table: "EksperciGorski");

            migrationBuilder.DropForeignKey(
                name: "FK_FragmentWycieczki_EksperciGorski_IdUz",
                table: "FragmentWycieczki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sezon_KsiazeczkaGOTPTTKs_NumerK",
                table: "Sezon");

            migrationBuilder.DropForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTKs_NumerK",
                table: "Turysta");

            migrationBuilder.DropForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTKs_NumerK",
                table: "Wycieczka");

            migrationBuilder.DropIndex(
                name: "IX_Turysta_IdA",
                table: "Turysta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsiazeczkaGOTPTTKs",
                table: "KsiazeczkaGOTPTTKs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EksperciGorski",
                table: "EksperciGorski");

            migrationBuilder.DeleteData(
                table: "EksperciGorski",
                keyColumn: "IdUz",
                keyValue: "22923dfe-c5a2-4f8c-8d5c-dbc8de208b38");

            migrationBuilder.DeleteData(
                table: "EksperciGorski",
                keyColumn: "IdUz",
                keyValue: "672e4d89-8a65-4171-a757-60a0271a2148");

            migrationBuilder.DeleteData(
                table: "EksperciGorski",
                keyColumn: "IdUz",
                keyValue: "c5186eea-0e69-4523-96e3-e69841245e5a");

            migrationBuilder.DeleteData(
                table: "EksperciGorski",
                keyColumn: "IdUz",
                keyValue: "f97cf24a-826f-4bb7-86dc-fb3dd75db49e");

            migrationBuilder.DeleteData(
                table: "KsiazeczkaGOTPTTKs",
                keyColumn: "NumerK",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KsiazeczkaGOTPTTKs",
                keyColumn: "NumerK",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KsiazeczkaGOTPTTKs",
                keyColumn: "NumerK",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Legitymacja_ObszarGorski",
                keyColumns: new[] { "NumerL", "NazwaOG" },
                keyValues: new object[] { "1111", "A1" });

            migrationBuilder.DeleteData(
                table: "Legitymacja_ObszarGorski",
                keyColumns: new[] { "NumerL", "NazwaOG" },
                keyValues: new object[] { "1111", "C3" });

            migrationBuilder.DeleteData(
                table: "Legitymacja_ObszarGorski",
                keyColumns: new[] { "NumerL", "NazwaOG" },
                keyValues: new object[] { "1111p", "C3" });

            migrationBuilder.DeleteData(
                table: "Legitymacja_ObszarGorski",
                keyColumns: new[] { "NumerL", "NazwaOG" },
                keyValues: new object[] { "2222", "A2" });

            migrationBuilder.DeleteData(
                table: "Legitymacja_ObszarGorski",
                keyColumns: new[] { "NumerL", "NazwaOG" },
                keyValues: new object[] { "2222", "C3" });

            migrationBuilder.DeleteData(
                table: "Turysta",
                keyColumn: "IdUz",
                keyValue: "24412758-bf78-4b21-a421-cf1b349683f1");

            migrationBuilder.DeleteData(
                table: "Turysta",
                keyColumn: "IdUz",
                keyValue: "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d");

            migrationBuilder.DeleteData(
                table: "Adres",
                keyColumn: "IdA",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adres",
                keyColumn: "IdA",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Legitymacje",
                keyColumn: "NumerL",
                keyValue: "1111");

            migrationBuilder.DeleteData(
                table: "Legitymacje",
                keyColumn: "NumerL",
                keyValue: "1111p");

            migrationBuilder.DeleteData(
                table: "Legitymacje",
                keyColumn: "NumerL",
                keyValue: "2222");

            migrationBuilder.DeleteData(
                table: "Legitymacje",
                keyColumn: "NumerL",
                keyValue: "2222p");

            migrationBuilder.RenameTable(
                name: "KsiazeczkaGOTPTTKs",
                newName: "KsiazeczkaGOTPTTK");

            migrationBuilder.RenameTable(
                name: "EksperciGorski",
                newName: "EkspertGorski");

            migrationBuilder.RenameIndex(
                name: "IX_EksperciGorski_NumerL",
                table: "EkspertGorski",
                newName: "IX_EkspertGorski_NumerL");

            migrationBuilder.RenameIndex(
                name: "IX_EksperciGorski_IdA",
                table: "EkspertGorski",
                newName: "IX_EkspertGorski_IdA");

            migrationBuilder.AddColumn<string>(
                name: "IdUz",
                table: "Adres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsiazeczkaGOTPTTK",
                table: "KsiazeczkaGOTPTTK",
                column: "NumerK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EkspertGorski",
                table: "EkspertGorski",
                column: "IdUz");

            migrationBuilder.CreateIndex(
                name: "IX_Turysta_IdA",
                table: "Turysta",
                column: "IdA",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EkspertGorski_Adres_IdA",
                table: "EkspertGorski",
                column: "IdA",
                principalTable: "Adres",
                principalColumn: "IdA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EkspertGorski_AspNetUsers_IdUz",
                table: "EkspertGorski",
                column: "IdUz",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EkspertGorski_Legitymacje_NumerL",
                table: "EkspertGorski",
                column: "NumerL",
                principalTable: "Legitymacje",
                principalColumn: "NumerL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FragmentWycieczki_EkspertGorski_IdUz",
                table: "FragmentWycieczki",
                column: "IdUz",
                principalTable: "EkspertGorski",
                principalColumn: "IdUz",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sezon_KsiazeczkaGOTPTTK_NumerK",
                table: "Sezon",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turysta_KsiazeczkaGOTPTTK_NumerK",
                table: "Turysta",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wycieczka_KsiazeczkaGOTPTTK_NumerK",
                table: "Wycieczka",
                column: "NumerK",
                principalTable: "KsiazeczkaGOTPTTK",
                principalColumn: "NumerK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
