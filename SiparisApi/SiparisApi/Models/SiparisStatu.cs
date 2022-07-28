using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisApi.Models
{
    public class SiparisStatu
    {
        public int siparisNo { get; set; }
        public SiparisDurum siparisDurum { get; set; }
        public DateTime? siparisDurumDegisimTarihi { get; set; }
    }
}
