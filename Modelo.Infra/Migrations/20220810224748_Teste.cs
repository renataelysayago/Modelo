using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Data.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuario");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 19, 47, 48, 503, DateTimeKind.Local).AddTicks(9537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "Nome" },
                values: new object[] { new Guid("18f0ad2d-e725-48f9-8020-d08f463bf5aa"), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "userdefault@gmail.com", "User Default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("18f0ad2d-e725-48f9-8020-d08f463bf5aa"));

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuarios");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "usuarios",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "usuarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 10, 19, 47, 48, 503, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");
        }
    }
}
