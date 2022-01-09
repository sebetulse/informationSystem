#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using informationSystem.Models;

namespace informationSystem.Data
{
    public class informationSystemContext : DbContext
    {
        public informationSystemContext (DbContextOptions<informationSystemContext> options)
            : base(options)
        {
            
        }

        public DbSet<informationSystem.Models.Mufredat> Mufredat { get; set; }

        public DbSet<informationSystem.Models.Ders> Dersler { get; set; }

        public DbSet<informationSystem.Models.Iletisim> ILETISIM { get; set; }

        public DbSet<informationSystem.Models.MufredatDersler> Mufredat_Dersler { get; set; }

        public DbSet<informationSystem.Models.Ogrenci> OGRENCI { get; set; }

        

        public DbSet<informationSystem.Models.Kimlik> KIMLIK { get; set; }

        

        public DbSet<informationSystem.Models.Kullanici> KULLANICILAR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Kullanici>()
                .HasOne(b => b.Kimlik)
                .WithOne(k => k.Kullanici)
                .HasForeignKey<Kullanici>(b => b.KIMLIK_ID);

            modelBuilder.Entity<Kimlik>()
                .HasOne(b => b.Iletisim)
                .WithOne(k => k.Kimlik)
                .HasForeignKey<Kimlik>(b => b.ILETISIM_ID);

            modelBuilder.Entity<Ogrenci>()
                .HasOne(b => b.Kimlik)
                .WithOne(k => k.Ogrenci)
                .HasForeignKey<Ogrenci>(b => b.KIMLIK_ID);
            */

        }


    }
}
