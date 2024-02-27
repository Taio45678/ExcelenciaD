using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExcelenciaD_API.Migrations
{
    /// <inheritdoc />
    public partial class llenar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "LastName", "Name", "Phone", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "casita 444", "Santiago del Estero", "Argentina", "emaildeprueba@prueba.com", "Casagrande", "Claudio David", "3854023721", new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1140) },
                    { 2, "Casa de lucas", "Cordoba", "Argentina", "pruebadelucas@mail.com", "Maldonado", "Lucas", "3854037772", new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1178) },
                    { 3, "Casa de nahuel", "Buenos Aires", "Argentina", "maildenahuel@mail.com", "Leal", "Nahuel", "3859842345", new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1187) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
