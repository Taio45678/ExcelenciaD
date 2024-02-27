using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelenciaD_API.Migrations
{
    /// <inheritdoc />
    public partial class FinalizadalaBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(118));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 6, 19, 30, 456, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 6, 19, 30, 456, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 6, 19, 30, 456, DateTimeKind.Local).AddTicks(5913));
        }
    }
}
