﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcTicariOtomasyonu.Models.Siniflar;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Current
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        public string ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string sehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string mail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string sifre { get; set; }

        public bool durum { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}