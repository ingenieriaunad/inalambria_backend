using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proveedoresbackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    IdProvider = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.IdProvider);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdProvider = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Providers_IdProvider",
                        column: x => x.IdProvider,
                        principalTable: "Providers",
                        principalColumn: "IdProvider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    IdSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sales_Products_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Email", "Identification", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("4dab72fe-beb5-42dd-9601-61e7691d17c6"), "proveedor2@inalambria.com", "987654321", "Proveedor 2", "987654321" },
                    { new Guid("8ff00858-4005-4ab3-8fa6-701b9f93f6ef"), "proveedor1@inalambria.com", "123456789", "Proveedor 1", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "IdProvider", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("a99ed444-60ba-489d-8e66-d62eb1f67762"), new Guid("4dab72fe-beb5-42dd-9601-61e7691d17c6"), "Producto 2", 2000, 20 },
                    { new Guid("b775477b-8c4d-4d7b-964b-092497ea8935"), new Guid("8ff00858-4005-4ab3-8fa6-701b9f93f6ef"), "Producto 1", 1000, 10 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "IdSale", "Date", "IdProducto", "Quantity", "Total" },
                values: new object[,]
                {
                    { new Guid("3c694f64-8e17-4f7a-8bc2-a901b5d2bac4"), new DateTime(2023, 1, 25, 22, 30, 32, 448, DateTimeKind.Local).AddTicks(7131), new Guid("b775477b-8c4d-4d7b-964b-092497ea8935"), 1, 1000 },
                    { new Guid("7678cb8e-50c6-447b-85ae-32e11a9e447b"), new DateTime(2023, 1, 25, 22, 30, 32, 448, DateTimeKind.Local).AddTicks(7151), new Guid("a99ed444-60ba-489d-8e66-d62eb1f67762"), 2, 4000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProvider",
                table: "Products",
                column: "IdProvider");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdProducto",
                table: "Sales",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
