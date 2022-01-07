using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWatchList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Data
{
    public class MyWatchListContext : IdentityDbContext<IdentityUser>
    {
        public MyWatchListContext(DbContextOptions<MyWatchListContext> options) : base(options) { }
        
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Aflevering> Afleveringen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<GebruikerSerie> GebruikerSeries { get; set; }
        public DbSet<Maakte> Maaktes { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Seizoen> Seizoenen { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<SpeeltIn> SpeeltIns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Acteur>().ToTable("Acteur");
            modelBuilder.Entity<Aflevering>().ToTable("Aflevering");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<Maakte>().ToTable("Maakte");
            modelBuilder.Entity<Seizoen>().ToTable("Seizoen");
            modelBuilder.Entity<Serie>().ToTable("Serie");
            modelBuilder.Entity<GebruikerSerie>().ToTable("GebruikerSerie");
            modelBuilder.Entity<SpeeltIn>().ToTable("SpeeltIn");
            modelBuilder.Entity<SpeeltIn>().HasKey(x => new { x.ActeurID, x.SerieID });
            modelBuilder.Entity<SpeeltIn>().HasOne(x => x.Serie).WithMany(y => y.SpeeltIn).HasForeignKey(z => z.ActeurID);
            modelBuilder.Entity<SpeeltIn>().HasOne(x => x.Acteur).WithMany(y => y.SpeeltIn).HasForeignKey(z => z.SerieID);



        }
    }
}
