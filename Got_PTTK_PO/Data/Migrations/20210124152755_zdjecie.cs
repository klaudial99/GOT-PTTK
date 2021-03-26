using Microsoft.EntityFrameworkCore.Migrations;

namespace Got_PTTK_PO.Data.Migrations
{
    public partial class zdjecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragmentWycieczki_Trasa_NazwaT_NazwaPP_NazwaPK",
                table: "FragmentWycieczki");

            migrationBuilder.AlterColumn<string>(
                name: "NazwaPP",
                table: "FragmentWycieczki",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NazwaPK",
                table: "FragmentWycieczki",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoZaliczenia",
                table: "FragmentWycieczki",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PowodOdrzucenia",
                table: "FragmentWycieczki",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZdjecieDowod",
                table: "FragmentWycieczki",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FragmentWycieczki_Trasa_NazwaT_NazwaPP_NazwaPK",
                table: "FragmentWycieczki",
                columns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                principalTable: "Trasa",
                principalColumns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragmentWycieczki_Trasa_NazwaT_NazwaPP_NazwaPK",
                table: "FragmentWycieczki");

            migrationBuilder.DropColumn(
                name: "DoZaliczenia",
                table: "FragmentWycieczki");

            migrationBuilder.DropColumn(
                name: "PowodOdrzucenia",
                table: "FragmentWycieczki");

            migrationBuilder.DropColumn(
                name: "ZdjecieDowod",
                table: "FragmentWycieczki");

            migrationBuilder.AlterColumn<string>(
                name: "NazwaPP",
                table: "FragmentWycieczki",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "NazwaPK",
                table: "FragmentWycieczki",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_FragmentWycieczki_Trasa_NazwaT_NazwaPP_NazwaPK",
                table: "FragmentWycieczki",
                columns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                principalTable: "Trasa",
                principalColumns: new[] { "NazwaT", "NazwaPP", "NazwaPK" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
