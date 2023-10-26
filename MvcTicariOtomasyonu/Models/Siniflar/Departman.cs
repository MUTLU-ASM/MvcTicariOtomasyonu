using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ad { get; set; }

        public ICollection<Personel> personels { get; set; }
    }
}