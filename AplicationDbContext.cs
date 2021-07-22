using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application1.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }

        public DbSet<Registro> Registro { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Zona> zona { get; set; }

        /*protected override OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Zona>()
                .HasMany(p => p.sectores)
                .WithMany(g => g.zonas)
                .UsingEntity<generos>(
                );

            //Base.OnModelCreating(modelBuilder)
        }*/

    }

   
}
