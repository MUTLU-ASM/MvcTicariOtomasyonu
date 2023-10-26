﻿using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string sehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string mail { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}