using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string marka { get; set; }

        public short stok { get; set; }
        public decimal alisFiyat { get; set; }
        public decimal satisFiyat { get; set; }
        public bool durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string gorsel { get; set; }

        public int kategoriId { get; set; }
        public virtual Kategori kategori { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}