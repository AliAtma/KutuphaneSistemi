using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Model
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public char Cinsiyet { get; set; }
        public bool MusteriDurumu { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
