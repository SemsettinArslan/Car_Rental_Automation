using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama
{
    public class Musteri
    {
        public int musteriId { get; set; }
        public string tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefonNumarasi{ get; set; }
        public string mail { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string adres { get; set; }
        public string ehliyetNumarasi { get; set; }
        public DateTime ehliyetGecerlilikSuresi { get; set; }
        public int kiraladigiAracSayisi { get; set; }
        public string musteriResmi { get; set; }
    }
}
