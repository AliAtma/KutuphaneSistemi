using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Mapping
{
    public class UrunMap : EntityTypeConfiguration<Urun>
    {
        public UrunMap()
        {
            this.ToTable("tblUrun");
            this.Property(p => p.UrunId).HasColumnType("int");
            this.Property(p => p.UrunId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UrunAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.UrunStok).HasColumnType("int");
            this.Property(p => p.UrunKodu).HasColumnType("int");
            this.Property(p => p.UrunFiyat).HasColumnType("int");

            this.HasRequired(p => p.Kategori).WithMany(p => p.Uruns).HasForeignKey(p => p.KategoriId);
        }
    }
}
