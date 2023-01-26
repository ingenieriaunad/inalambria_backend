using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proveedoresbackend.Migrations
{
    /// <inheritdoc />
    public partial class IdentificationUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("3c694f64-8e17-4f7a-8bc2-a901b5d2bac4"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("7678cb8e-50c6-447b-85ae-32e11a9e447b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("a99ed444-60ba-489d-8e66-d62eb1f67762"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("b775477b-8c4d-4d7b-964b-092497ea8935"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("4dab72fe-beb5-42dd-9601-61e7691d17c6"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("8ff00858-4005-4ab3-8fa6-701b9f93f6ef"));

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Providers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Email", "Identification", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("263f08aa-fa5d-49af-9ea8-693eb963ed40"), "proveedor1@inalambria.com", "123456789", "Proveedor 1", "123456789" },
                    { new Guid("56393997-612c-49a9-89ba-c15c31641f15"), "proveedor2@inalambria.com", "987654321", "Proveedor 2", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "IdProvider", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("673580d1-38aa-4588-8230-a7f39d981c8e"), new Guid("263f08aa-fa5d-49af-9ea8-693eb963ed40"), "Producto 1", 1000, 10 },
                    { new Guid("e56125fa-8267-4490-98b6-060579efe311"), new Guid("56393997-612c-49a9-89ba-c15c31641f15"), "Producto 2", 2000, 20 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "IdSale", "Date", "IdProducto", "Quantity", "Total" },
                values: new object[,]
                {
                    { new Guid("683b1d6c-d73d-4416-b323-fd733b79bd7a"), new DateTime(2023, 1, 26, 10, 28, 28, 596, DateTimeKind.Local).AddTicks(7901), new Guid("e56125fa-8267-4490-98b6-060579efe311"), 2, 4000 },
                    { new Guid("ed10750c-ce05-4d23-a8a9-0cb24a10ac51"), new DateTime(2023, 1, 26, 10, 28, 28, 596, DateTimeKind.Local).AddTicks(7887), new Guid("673580d1-38aa-4588-8230-a7f39d981c8e"), 1, 1000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Identification",
                table: "Providers",
                column: "Identification",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Providers_Identification",
                table: "Providers");

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("683b1d6c-d73d-4416-b323-fd733b79bd7a"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("ed10750c-ce05-4d23-a8a9-0cb24a10ac51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("673580d1-38aa-4588-8230-a7f39d981c8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("e56125fa-8267-4490-98b6-060579efe311"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("263f08aa-fa5d-49af-9ea8-693eb963ed40"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("56393997-612c-49a9-89ba-c15c31641f15"));

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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
        }
    }
}
