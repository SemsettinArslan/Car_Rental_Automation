using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama
{
    public class Arac
    {
        public int aracId { get; set; }
        public string plaka { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string yıl { get; set; }
        public int kisiSayisi { get; set; }
        public int sonKm { get; set; }
        public string yakitTuru { get; set; }
        public string vitesTuru { get; set; }
        public int gunlukUcret { get; set; }
        public bool aktifMi { get; set; }
        public bool kiradaMi { get; set; }
        public int hasarKaydi { get; set; }
        public DateTime muayeneTarihi { get; set; }
        public DateTime kiraBaslangic { get; set; }
        public DateTime kiraBitis { get; set; }
        public int kiraMusteriId { get; set; }
        public string aracResmi { get; set; }
    }
}
