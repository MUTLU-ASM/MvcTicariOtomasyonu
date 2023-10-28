using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Personel
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
        [StringLength(250)]
        public string gorsel { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }

        public int departmanId { get; set; }
        public virtual Departman departman { get; set; }
    }
}