using ExcelenciaD_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExcelenciaD_API.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
        .HasOne(p => p.Customer)
        .WithMany(c => c.Pedidos)
        .HasForeignKey(p => p.CustomerId)
        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    Name = "Claudio David",
                    LastName = "Casagrande",
                    Email = "emaildeprueba@prueba.com",
                    Phone = "3854023721",
                    Address = "25 de mayo 339",
                    City = "Santiago del Estero",
                    Country = "Argentina",
                    RegisterDate = DateTime.Now
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Lucas",
                    LastName = "Maldonado",
                    Email = "pruebadelucas@mail.com",
                    Phone = "3854037772",
                    Address = "Manzana 18 lote 24 siglo xx",
                    City = "Cordoba",
                    Country = "Argentina",
                    RegisterDate = DateTime.Now
                },
                new Customer()
                {
                    Id = 3,
                    Name = "Nahuel",
                    LastName = "Leal",
                    Email = "maildenahuel@mail.com",
                    Phone = "3859842345",
                    Address = "Manzana 30 lote 9 siglo xxi",
                    City = "Buenos Aires",
                    Country = "Argentina",
                    RegisterDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Pedido>().HasData(
                new Pedido()
                {
                    Id = 1,
                    Detalles = "Pack Ahorro Huggies Azul x60 XXG.",
                    Total="10,000",
                    CustomerId = 1
                },
                 new Pedido()
                 {
                     Id = 4,
                     Detalles = "Huggies Rojo x60  XG.",
                     Total = "100000",
                     CustomerId = 1
                 },
                  new Pedido()
                  {
                      Id = 2,
                      Detalles = "Pack Ahorro Huggies Azul x60 M.",
                      Total = "100,000",
                      CustomerId = 2
                  },
                   new Pedido()
                   {
                       Id = 3,
                       Detalles = "Pack Ahorro Huggies Amarillo x60 G .",
                       Total = "100,000",
                       CustomerId = 3
                   }

            );

       
        }
    }
}
