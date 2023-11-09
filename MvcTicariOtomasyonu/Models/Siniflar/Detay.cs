using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string bilgi { get; set; }
    }
}