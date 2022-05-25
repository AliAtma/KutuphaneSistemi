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
    public class PersonelMap: EntityTypeConfiguration<Personel>
    {
        public PersonelMap()
        {
            this.ToTable("tblPersonel");
            this.Property(p => p.PersonelId).HasColumnType("int");
            this.Property(p => p.PersonelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.PersonelAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.PersonelEmail).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.PersonelSoyadi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.PersonelParola).HasColumnType("varchar").HasMaxLength(30);

        }
    }
}
