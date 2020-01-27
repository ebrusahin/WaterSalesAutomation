using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuOtomasyonu.MODEL
{
    public class MusteriModel
    {

        public int musteriID { get; set; }
        public string musteriAdi { get; set; }
        public string musteriSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public int siparisID { get; set; }

        public SiparisModel siparis = new SiparisModel();

    }
}
