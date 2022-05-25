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
    public class MusteriMap : EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            this.ToTable("tblMusteri");
            this.Property(p => p.MusteriId).HasColumnType("int");
            this.Property(p => p.MusteriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MusteriAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriSoyadi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.DogumTarihi).HasColumnType("date");
        }
    }
}