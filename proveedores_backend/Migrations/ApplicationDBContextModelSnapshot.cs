﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proveedores_backend;

#nullable disable

namespace proveedoresbackend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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
                            IdProduct = new Guid("77ab317c-a7b6-4069-9a04-bc04bed81d64"),
                            IdProvider = new Guid("e1527492-e961-4c5b-8b66-c70dc9b46b37"),
                            Name = "Producto 1",
                            Price = 1000,
                            Stock = 10
                        },
                        new
                        {
                            IdProduct = new Guid("be5b56df-9782-4ac7-a520-03c577c790e7"),
                            IdProvider = new Guid("1cf8736f-4a91-4024-b487-ce87ccb3bc0c"),
                            Name = "Producto 2",
                            Price = 2000,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("proveedores_backend.Models.Provider", b =>
                {
                    b.Property<Guid>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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
                            IdProvider = new Guid("e1527492-e961-4c5b-8b66-c70dc9b46b37"),
                            Email = "proveedor1@inalambria.com",
                            Identification = "123456789",
                            Name = "Proveedor 1",
                            Phone = "123456789"
                        },
                        new
                        {
                            IdProvider = new Guid("1cf8736f-4a91-4024-b487-ce87ccb3bc0c"),
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
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

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
                            IdSale = new Guid("57ed4942-bc66-45ff-8c1f-e50ae023537e"),
                            Date = new DateTime(2023, 1, 26, 10, 47, 17, 408, DateTimeKind.Local).AddTicks(2826),
                            IdProducto = new Guid("77ab317c-a7b6-4069-9a04-bc04bed81d64"),
                            Quantity = 1,
                            Total = 1000
                        },
                        new
                        {
                            IdSale = new Guid("1ab6891b-53f6-43f9-b724-fd16762cb15c"),
                            Date = new DateTime(2023, 1, 26, 10, 47, 17, 408, DateTimeKind.Local).AddTicks(2851),
                            IdProducto = new Guid("be5b56df-9782-4ac7-a520-03c577c790e7"),
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