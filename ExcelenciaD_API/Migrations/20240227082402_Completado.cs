using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelenciaD_API.Migrations
{
    /// <inheritdoc />
    public partial class Completado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "CustomerId", "Detalles", "FechaPedido", "Total" },
                values: new object[] { 1, 1, "Pack Ahorro Huggies Azul x60 XXG.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10000" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CustomerId",
                table: "Pedidos",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 2, 26, 17, 12, 30, 544, DateTimeKind.Local).AddTicks(1187));
        }
    }
}
