using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Data.Migrations
{
    public partial class Inclusãodocamposenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 16, 26, 43, 560, DateTimeKind.Local).AddTicks(5101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 10, 19, 47, 48, 503, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "SenhaInicial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 19, 47, 48, 503, DateTimeKind.Local).AddTicks(9537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 16, 26, 43, 560, DateTimeKind.Local).AddTicks(5101));
        }
    }
}
