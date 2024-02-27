using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExcelenciaD_API.Migrations
{
    /// <inheritdoc />
    public partial class NuevaDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "25 de mayo 339", new DateTime(2024, 2, 27, 9, 20, 47, 645, DateTimeKind.Local).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "Manzana 18 lote 24 siglo xx", new DateTime(2024, 2, 27, 9, 20, 47, 645, DateTimeKind.Local).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "Manzana 30 lote 9 siglo xxi", new DateTime(2024, 2, 27, 9, 20, 47, 645, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Total",
                value: "10,000");

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "CustomerId", "Detalles", "FechaPedido", "Total" },
                values: new object[,]
                {
                    { 2, 2, "Pack Ahorro Huggies Azul x60 M.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100,000" },
                    { 3, 3, "Pack Ahorro Huggies Amarillo x60 G .", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100,000" },
                    { 4, 1, "Huggies Rojo x60  XG.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "casita 444", new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "Casa de lucas", new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "RegisterDate" },
                values: new object[] { "Casa de nahuel", new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(118) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Total",
                value: "10000");
        }
    }
}
