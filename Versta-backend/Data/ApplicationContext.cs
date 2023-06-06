using System.Collections.Generic;
using Versta.Models;
using Microsoft.EntityFrameworkCore;

namespace Versta.Data
{
    public class ApplicationContext : DbContext
    {
        private string dataSource = @"DESKTOP-O98QPDO\SQLEXPRESS";
        private string dataBase = "Versta";
        private string userName = "DESKTOP-O98QPDO\\User";
        private string connectionString;
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.connectionString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + dataBase + ";Persist Security Info=True;User ID=" + userName + ";Trusted_Connection=True;" + ";TrustServerCertificate=True;" + "Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => new { o.SenderId, o.Id });
            modelBuilder.Entity<Sender>().HasMany(s => s.Orders).WithOne(o => o.Sender).HasForeignKey(o => o.SenderId);

            modelBuilder.Entity<Order>().HasKey(o => new { o.RecipientId, o.Id });
            modelBuilder.Entity<Recipient>().HasMany(r => r.Orders).WithOne(o => o.Recipient).HasForeignKey(o => o.RecipientId);

            modelBuilder.Entity<Cargo>()
                .HasOne(c => c.Order)
                .WithOne(c => c.Cargo)
                .HasForeignKey<Order>(c => c.CargoId)
                .IsRequired();
        }
    }
}
