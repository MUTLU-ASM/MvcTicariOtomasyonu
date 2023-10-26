using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int id { get; set; }
        public DateTime tarih { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal toplamTutar { get; set; }

        public Urun urun { get; set; }
        public Cariler cariler { get; set; }
        public Personel personel { get; set; }
    }
}