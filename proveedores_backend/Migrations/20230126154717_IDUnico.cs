using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proveedoresbackend.Migrations
{
    /// <inheritdoc />
    public partial class IDUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSale",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProvider",
                table: "Providers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProduct",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Email", "Identification", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("1cf8736f-4a91-4024-b487-ce87ccb3bc0c"), "proveedor2@inalambria.com", "987654321", "Proveedor 2", "987654321" },
                    { new Guid("e1527492-e961-4c5b-8b66-c70dc9b46b37"), "proveedor1@inalambria.com", "123456789", "Proveedor 1", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "IdProvider", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("77ab317c-a7b6-4069-9a04-bc04bed81d64"), new Guid("e1527492-e961-4c5b-8b66-c70dc9b46b37"), "Producto 1", 1000, 10 },
                    { new Guid("be5b56df-9782-4ac7-a520-03c577c790e7"), new Guid("1cf8736f-4a91-4024-b487-ce87ccb3bc0c"), "Producto 2", 2000, 20 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "IdSale", "Date", "IdProducto", "Quantity", "Total" },
                values: new object[,]
                {
                    { new Guid("1ab6891b-53f6-43f9-b724-fd16762cb15c"), new DateTime(2023, 1, 26, 10, 47, 17, 408, DateTimeKind.Local).AddTicks(2851), new Guid("be5b56df-9782-4ac7-a520-03c577c790e7"), 2, 4000 },
                    { new Guid("57ed4942-bc66-45ff-8c1f-e50ae023537e"), new DateTime(2023, 1, 26, 10, 47, 17, 408, DateTimeKind.Local).AddTicks(2826), new Guid("77ab317c-a7b6-4069-9a04-bc04bed81d64"), 1, 1000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("1ab6891b-53f6-43f9-b724-fd16762cb15c"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: new Guid("57ed4942-bc66-45ff-8c1f-e50ae023537e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("77ab317c-a7b6-4069-9a04-bc04bed81d64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: new Guid("be5b56df-9782-4ac7-a520-03c577c790e7"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("1cf8736f-4a91-4024-b487-ce87ccb3bc0c"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "IdProvider",
                keyValue: new Guid("e1527492-e961-4c5b-8b66-c70dc9b46b37"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSale",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProvider",
                table: "Providers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProduct",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

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
        }
    }
}
