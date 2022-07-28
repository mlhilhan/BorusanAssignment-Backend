using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisApi.Models
{
    public class Siparis
    {
        [Key]
        public int siparisNo { get; set; }

        public string cikisAdresi { get; set; }
        public string varisAdresi { get; set; }
        public int miktar { get; set; }
        public string miktarBirim{ get; set; }
        public int agirlik { get; set; }
        public string agirlikBirim { get; set; }
        public int malzemeKodu { get; set; }
        public string malzemeAdi { get; set; }
        public string siparisNot { get; set; }
        public SiparisDurum siparisDurum { get; set; }
        public string siparisDurumStr { get { return siparisDurum.ToString(); } }
        public DateTime? siparisDurumDegisimTarihi { get; set; }
    }

    public enum SiparisDurum
    {
        SiparisAlindi = 0,
        YolaCikti = 1,
        DagitimMerkezinde = 2,
        DagitimaCikti = 3,
        TeslimEdildi = 4,
        TeslimEdilemedi = 5
    }
}
