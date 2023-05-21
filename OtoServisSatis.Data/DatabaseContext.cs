using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext:DbContext
    {
        //veri tabanindaki  tablolar burada olusturuluyor. Dbcontext sinifina ait Dbset nesnesi ile Arac sinifimiz cagiriliyor. Yanindaki Araclar kismi ise 
        //veri tabanindaki adini temsil eder
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar{ get; set; }
        public DbSet<Servis> Servisler { get; set; }

        //sql i burada tanimladik gerekli kutuphaneleri kurduk ve projeye db nin yolunu vererek dahil ettik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB; database=OtoServisSatis; integrated security=True; MultipleActiveResultSets=True;") ;

            base.OnConfiguring(optionsBuilder);
        }
        //onModelCreating modulu Dbcontext uzerinden turetilmistir bu metdo sayesinde Fluent api veya 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApi
            modelBuilder.Entity<Marka>().Property(m=>m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Admin",
                AktifMi=true,
                EklenmeTarihi=DateTime.Now,
                Email="admin@otoservissatis.com",
                KullaniciAdi="admin",
                Sifre="1234",
                //Rol=new Rol { Id = 1,},
                RolId=1,
                SoyAdi="admin",
                Telefon="0537"

            }) ;
            modelBuilder.Entity<Arac>().HasData(new Arac
            {
                Id = 1,
                Fiyati = 100,
                MarkaId = 1,
                Renk = "Kirmizi",
                Modeli = "focus",
                KasaTipi = "Sedan",
                SatistaMi = true,
                ModelYili = 1999,
                Notlar = "yok"

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
