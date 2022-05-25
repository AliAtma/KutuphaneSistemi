using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliHaydarAtma.Entites.Model
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelEmail { get; set; }
        public string PersonelParola { get; set; }
        public bool PersonelDurumu { get; set; }
    }
}
