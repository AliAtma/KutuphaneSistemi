using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Model
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAciklama { get; set; }
        public bool KategoriDurumu { get; set; }

        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
