using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiparisApi.Data;
using SiparisApi.Models;

namespace SiparisApi.Controllers
{
    [ApiController]
    public class SiparisController : ControllerBase
    {
        [HttpPost]
        [Route("api/siparisKabul")]
        public SiparisSonuc SiparisKabul([FromBody]Siparis siparis)
        {
            SiparisSonuc siparisSonuc;
            try
            {
                SiparisDBContext context = new SiparisDBContext();
                siparis.siparisDurum = SiparisDurum.SiparisAlindi;
                context.Siparis.Add(siparis);
                bool kaydetmeBasarili = context.SaveChanges() > 0;

                siparisSonuc = new SiparisSonuc()
                {
                    sistemSiparisNo = siparis.siparisNo,
                    musteriSiparisNo = siparis.siparisNo,
                    statu = kaydetmeBasarili ? 1 : 0,
                    hataAciklama = kaydetmeBasarili ? "" : "Veritabanına kayıt atılırken sorun oluştu."
                };
            }
            catch (Exception e)
            {
                siparisSonuc = new SiparisSonuc()
                {
                    sistemSiparisNo = 0,
                    musteriSiparisNo = siparis.siparisNo,
                    statu = 0,
                    hataAciklama = e.Message.Substring(0,500)
                };

                return siparisSonuc;
            }

            return siparisSonuc;
        }

        [HttpPut]
        [Route("api/statu")]
        public string StatuGuncelle([FromBody]SiparisStatu siparisStatu)
        {
            try
            {
                SiparisDBContext context = new SiparisDBContext();
                var siparis = context.Siparis.SingleOrDefault(x => x.siparisNo == siparisStatu.siparisNo);

                if (siparis == null)
                    return siparisStatu.siparisNo + " nolu sipariş bulunamadı.";

                siparis.siparisDurum = siparisStatu.siparisDurum;
                siparis.siparisDurumDegisimTarihi = DateTime.Now;
                context.SaveChanges();

                return "Başarılı bir şekilde güncellendi.";
            }
            catch (Exception e)
            {
                return e.Message.Substring(0,500);
            }

        }

        [HttpGet]
        [Route("api/siparisler")]
        public List<Siparis> Siparisler()
        {
            SiparisDBContext context = new SiparisDBContext();
            return context.Siparis.ToList();
        }

        [HttpGet]
        [Route("api/merhaba")]
        public string Merhaba()
        {
            return "Merhaba";
        }
    }
}
