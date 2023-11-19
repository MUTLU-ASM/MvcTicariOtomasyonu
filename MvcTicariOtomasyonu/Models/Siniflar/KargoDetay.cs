using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string takipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string personel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string alici { get; set; }

        public DateTime tarih { get; set; }
    }
}