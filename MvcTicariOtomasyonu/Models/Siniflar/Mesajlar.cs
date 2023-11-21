using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string icerik { get; set; }

        [Column(TypeName = "Date")]
        public DateTime tarih { get; set; }
    }
}