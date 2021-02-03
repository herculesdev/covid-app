using System;
using System.IO;
using CovidApp.Core.Entities;
using CovidApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CovidApp.Infra.Data.Context
{
    public class CovidDbContext : DbContext
    {
        public DbSet<CasoCovid> CasosCovid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Covid.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CasoCovidMap());
        }
    }
}