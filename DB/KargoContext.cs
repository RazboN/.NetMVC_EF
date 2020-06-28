using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_EF_Deneme.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_EF_Deneme.DB
{
    public class KargoContext : DbContext
    {
        private const string connectionString = "Server=DESKTOP-6PBOME5;Database=MVC_EF;" +
            "Trusted_Connection=True;";
        IConfiguration _iconfiguration;

        public KargoContext(IConfiguration iconfiguration) {
            _iconfiguration = iconfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(_iconfiguration.GetSection("Data")
                .GetSection("ConnectionString").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Kargo>().ToTable("Kargo");
            modelBuilder.Entity<KargoDetay>().HasBaseType<Kargo>();
        }

        public DbSet<KargoDetay> kargolar { get; set; }
    }
}
