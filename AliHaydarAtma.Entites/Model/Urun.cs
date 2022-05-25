using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AliHaydarAtma.Entites.Model
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunKodu { get; set; }
        public int UrunFiyat { get; set; }
        public int UrunStok { get; set; }
        public bool UrunDurumu { get; set; }
        public int KategoriId { get; set; }

        public string KategoriAdi { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }

    }
}
