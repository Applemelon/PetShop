using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Ctx.Repository
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt) { }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<PetColorLine> PCLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(p => p.owner).WithMany(o => o.pets).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Owner>().HasMany(o => o.pets).WithOne(p => p.owner).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PetColorLine>().HasKey(pc => new { pc.colorId, pc.petId });
        }
    }
}
