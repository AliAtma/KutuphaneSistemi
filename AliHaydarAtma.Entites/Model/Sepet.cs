using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Model
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int SepetAdet { get; set; }
        public int SepetToplam { get; set; }
        public bool SepetDurumu { get; set; }

        public int MusteriId { get; set; }
        public int UrunId { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
