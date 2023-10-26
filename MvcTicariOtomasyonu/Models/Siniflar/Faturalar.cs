using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyonu.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string seriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string sıraNo { get; set; }
        public DateTime tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string vergiDairesi { get; set; }
        public DateTime saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string teslimVeren { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string teslimAlan { get; set; }

        public ICollection<FaturaKalem> faturaKalems { get; set; }
    }
}