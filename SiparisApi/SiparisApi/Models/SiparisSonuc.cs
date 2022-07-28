using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisApi.Models
{
    public class SiparisSonuc
    {
        public int musteriSiparisNo { get; set; }
        public int sistemSiparisNo { get; set; }
        public int statu { get; set; }
        public string hataAciklama { get; set; }
    }
}
