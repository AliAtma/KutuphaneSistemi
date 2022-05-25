using AliHaydarAtma.Entites.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Model
{
    public class SatisContext : DbContext
    {
        public SatisContext() : base("name=UrunEntites")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new SepetMap());
            modelBuilder.Configurations.Add(new UrunMap());
            modelBuilder.Configurations.Add(new PersonelMap());
        }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<Musteri> Musteri { get; set; }

        public DbSet<Sepet> Sepet { get; set; }

        public DbSet<Urun> Urun { get; set; }
        public DbSet<Personel> Personel { get; set; }
    }
}

