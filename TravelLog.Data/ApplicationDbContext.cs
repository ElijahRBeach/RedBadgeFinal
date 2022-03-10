using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelLog.Data.Entities;

namespace TravelLog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<StateEntity> States { get; set; }
        public DbSet<CityEntity> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateEntity>()
            .HasOne(s => s.Country)
            .WithMany(c => c.States)
            .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<CityEntity>()
            .HasOne(y => y.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(y => y.CountryId);

            modelBuilder.Entity<CityEntity>()
            .HasOne(s => s.State)
            .WithMany(y => y.Cities)
            .HasForeignKey(s => s.StateId);
        }
    }
}