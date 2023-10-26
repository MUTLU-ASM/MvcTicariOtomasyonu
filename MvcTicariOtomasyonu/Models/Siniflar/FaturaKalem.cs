using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string aciklama { get; set; }

        public int miktar { get; set; }
        public int birimFiyat { get; set; }
        public int tutar { get; set; }

        public Faturalar faturalar { get; set; }
    }
}