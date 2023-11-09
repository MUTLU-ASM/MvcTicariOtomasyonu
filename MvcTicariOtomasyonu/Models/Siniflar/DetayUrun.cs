using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class DetayUrun
    {
        public IEnumerable<Urun> urunDeger { get; set; }
        public IEnumerable<Detay> detayDeger { get; set; }
    }
}