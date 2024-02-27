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
                    Address = "casita 444",
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
                    Address = "Casa de lucas",
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
                    Address = "Casa de nahuel",
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
                    Total="10000",
                    CustomerId = 1
                }
                
            );

       
        }
    }
}
