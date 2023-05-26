using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceDemografi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Demografi> Demografis { get; set; }
        public DbSet<PhotoID> PhotoIDs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demografi>()
                .HasMany(d => d.PhotoIDs)
                .WithOne(p => p.Demografi)
                .HasForeignKey(p => p.DemografiId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}