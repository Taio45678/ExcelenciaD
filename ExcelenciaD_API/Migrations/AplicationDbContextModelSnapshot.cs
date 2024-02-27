﻿// <auto-generated />
using System;
using ExcelenciaD_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExcelenciaD_API.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExcelenciaD_API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "casita 444",
                            City = "Santiago del Estero",
                            Country = "Argentina",
                            Email = "emaildeprueba@prueba.com",
                            LastName = "Casagrande",
                            Name = "Claudio David",
                            Phone = "3854023721",
                            RegisterDate = new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(96)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Casa de lucas",
                            City = "Cordoba",
                            Country = "Argentina",
                            Email = "pruebadelucas@mail.com",
                            LastName = "Maldonado",
                            Name = "Lucas",
                            Phone = "3854037772",
                            RegisterDate = new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(115)
                        },
                        new
                        {
                            Id = 3,
                            Address = "Casa de nahuel",
                            City = "Buenos Aires",
                            Country = "Argentina",
                            Email = "maildenahuel@mail.com",
                            LastName = "Leal",
                            Name = "Nahuel",
                            Phone = "3859842345",
                            RegisterDate = new DateTime(2024, 2, 27, 7, 7, 58, 520, DateTimeKind.Local).AddTicks(118)
                        });
                });

            modelBuilder.Entity("ExcelenciaD_API.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Detalles = "Pack Ahorro Huggies Azul x60 XXG.",
                            FechaPedido = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = "10000"
                        });
                });

            modelBuilder.Entity("ExcelenciaD_API.Models.Pedido", b =>
                {
                    b.HasOne("ExcelenciaD_API.Models.Customer", "Customer")
                        .WithMany("Pedidos")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ExcelenciaD_API.Models.Customer", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}