﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proveedores_backend;

#nullable disable

namespace proveedoresbackend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230126152828_IdentificationUnica")]
    partial class IdentificationUnica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("proveedores_backend.Models.Product", b =>
                {
                    b.Property<Guid>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProvider")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdProvider");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            IdProduct = new Guid("673580d1-38aa-4588-8230-a7f39d981c8e"),
                            IdProvider = new Guid("263f08aa-fa5d-49af-9ea8-693eb963ed40"),
                            Name = "Producto 1",
                            Price = 1000,
                            Stock = 10
                        },
                        new
                        {
                            IdProduct = new Guid("e56125fa-8267-4490-98b6-060579efe311"),
                            IdProvider = new Guid("56393997-612c-49a9-89ba-c15c31641f15"),
                            Name = "Producto 2",
                            Price = 2000,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("proveedores_backend.Models.Provider", b =>
                {
                    b.Property<Guid>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdProvider");

                    b.HasIndex("Identification")
                        .IsUnique();

                    b.ToTable("Providers");

                    b.HasData(
                        new
                        {
                            IdProvider = new Guid("263f08aa-fa5d-49af-9ea8-693eb963ed40"),
                            Email = "proveedor1@inalambria.com",
                            Identification = "123456789",
                            Name = "Proveedor 1",
                            Phone = "123456789"
                        },
                        new
                        {
                            IdProvider = new Guid("56393997-612c-49a9-89ba-c15c31641f15"),
                            Email = "proveedor2@inalambria.com",
                            Identification = "987654321",
                            Name = "Proveedor 2",
                            Phone = "987654321"
                        });
                });

            modelBuilder.Entity("proveedores_backend.Models.Sale", b =>
                {
                    b.Property<Guid>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdSale");

                    b.HasIndex("IdProducto");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            IdSale = new Guid("ed10750c-ce05-4d23-a8a9-0cb24a10ac51"),
                            Date = new DateTime(2023, 1, 26, 10, 28, 28, 596, DateTimeKind.Local).AddTicks(7887),
                            IdProducto = new Guid("673580d1-38aa-4588-8230-a7f39d981c8e"),
                            Quantity = 1,
                            Total = 1000
                        },
                        new
                        {
                            IdSale = new Guid("683b1d6c-d73d-4416-b323-fd733b79bd7a"),
                            Date = new DateTime(2023, 1, 26, 10, 28, 28, 596, DateTimeKind.Local).AddTicks(7901),
                            IdProducto = new Guid("e56125fa-8267-4490-98b6-060579efe311"),
                            Quantity = 2,
                            Total = 4000
                        });
                });

            modelBuilder.Entity("proveedores_backend.Models.Product", b =>
                {
                    b.HasOne("proveedores_backend.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("IdProvider")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("proveedores_backend.Models.Sale", b =>
                {
                    b.HasOne("proveedores_backend.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("proveedores_backend.Models.Product", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("proveedores_backend.Models.Provider", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
