using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string yetki { get; set; }
    }
}