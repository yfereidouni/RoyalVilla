using Microsoft.EntityFrameworkCore;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Infrastructures.DAL.EF.Villas;
using RoyalVilla.Infrastructures.DAL.EF.VillasNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.Common
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillasNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VillaConfiguration());
            modelBuilder.ApplyConfiguration(new VillaNumberConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
