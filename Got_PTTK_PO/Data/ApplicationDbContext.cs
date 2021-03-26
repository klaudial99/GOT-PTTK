using System;
using System.Collections.Generic;
using System.Text;
using Got_PTTK_PO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Got_PTTK_PO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Punkt> Punkt { get; set; }
        public DbSet<ObszarGorski> ObszarGorski { get; set; }
        public DbSet<RegionGorski> RegionGorski { get; set; }
        public DbSet<TerenGorski> TerenGorski { get; set; }
        public DbSet<Trasa> Trasa { get; set; }
        public DbSet<Punkt_RegionGorski> Punkt_RegionGorski { get; set; }
        public DbSet<Punkt_TerenGorski> Punkt_TerenGorski { get; set; }
        public DbSet<Wycieczka> Wycieczka { get; set; }
        public DbSet<FragmentWycieczki> FragmentWycieczki { get; set; }
        public DbSet<Legitymacja> Legitymacje { get; set; }
        public DbSet<Legitymacja_ObszarGorski> Legitymacja_ObszarGorski { get; set; }
        public DbSet<KsiazeczkaGOTPTTK> KsiazeczkaGOTPTTKs { get; set; }
        public DbSet<EkspertGorski> EksperciGorski { get; set; }
        public DbSet<Adres> Adres { get; set; }
        public DbSet<Turysta> Turysta { get; set; }
        public DbSet<WylaczenieTrasy> WylaczenieTrasy { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Punkt_RegionGorski>()
                .HasKey(t => new { t.NazwaP, t.IdRG});

            modelBuilder.Entity<Punkt_RegionGorski>()
                .HasOne(cs => cs.Punkt)
                .WithMany(p => p.RegionyGorskie)
                .HasForeignKey(cs => cs.NazwaP);

            modelBuilder.Entity<Punkt_RegionGorski>()
                .HasOne(cs => cs.RegionGorski)
                .WithMany(s => s.PunktyWRegionie)
                .HasForeignKey(cs => cs.IdRG);

            modelBuilder.Entity<Punkt_TerenGorski>()
                .HasKey(t => new { t.NazwaP, t.NazwaTG });

            modelBuilder.Entity<Punkt_TerenGorski>()
                .HasOne(cs => cs.Punkt)
                .WithMany(p => p.TerenyGorskie)
                .HasForeignKey(cs => cs.NazwaP);

            modelBuilder.Entity<Punkt_TerenGorski>()
                .HasOne(cs => cs.TerenGorski)
                .WithMany(s => s.PunktyWTerenie)
                .HasForeignKey(cs => cs.NazwaTG);

            modelBuilder.Entity<Trasa>()
                .HasKey(t => new { t.NazwaT, t.NazwaPP, t.NazwaPK });

            modelBuilder.Entity<Trasa>()
                .HasOne(cs => cs.PunktPocz)
                .WithMany(p => p.TrasyRozpoczynane)
                .HasForeignKey(cs => cs.NazwaPP);

            modelBuilder.Entity<Trasa>()
                .HasOne(cs => cs.PunktKonc)
                .WithMany(p => p.TrasyKonczone)
                .HasForeignKey(cs => cs.NazwaPK).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Punkt>()
                .Property(p => p.Rodzaj)
                .HasConversion(v => v.ToString(),
                v => (Rodzaj_Punktu)Enum.Parse(typeof(Rodzaj_Punktu), v));

            modelBuilder.Entity<FragmentWycieczki>()
                .HasKey(t => new { t.IdW, t.NumerFW });

            modelBuilder.Entity<FragmentWycieczki>()
                .HasOne(cs => cs.Wycieczka)
                .WithMany(p => p.TrasyWycieczki)
                .HasForeignKey(cs => cs.IdW);

            modelBuilder.Entity<FragmentWycieczki>()
                .HasOne(cs => cs.Trasa)
                .WithMany(s => s.WycieczkiZTrasa)
                .HasForeignKey(cs => new { cs.NazwaT, cs.NazwaPP, cs.NazwaPK });

            modelBuilder.Entity<Legitymacja_ObszarGorski>()
                .HasKey(t => new { t.NumerL, t.NazwaOG });

            modelBuilder.Entity<Norma>()
                .HasKey(t => new { t.IdO, t.NumerN });

            modelBuilder.Entity<Norma_Sezon>()
                .HasKey(t => new { t.IdS, t.IdO, t.NumerN });

            modelBuilder.Entity<WylaczenieTrasy>()
                .HasOne(cs => cs.Trasa)
                .WithMany(p => p.WylaczeniaTrasy)
                .HasForeignKey(cs => new { cs.NazwaT, cs.NazwaPP, cs.NazwaPK });

            modelBuilder.Entity<WylaczenieTrasy>()
                .HasKey(t => new { t.DataPocz, t.NazwaPP, t.NazwaPK, t.NazwaT });

            modelBuilder.Entity<Trasa>()
                .HasMany(cs => cs.WylaczeniaTrasy)
                .WithOne(t => t.Trasa);


            modelBuilder.Seed();

        }
    }
}
