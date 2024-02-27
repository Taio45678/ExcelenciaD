using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelenciaD_API.Migrations
{
    /// <inheritdoc />
    public partial class BDDCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Customers_CustomerId",
                table: "Pedidos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Customers_CustomerId",
                table: "Pedidos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Customers_CustomerId",
                table: "Pedidos");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 5, 23, 59, 106, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 5, 23, 59, 106, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 27, 5, 23, 59, 106, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Customers_CustomerId",
                table: "Pedidos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
