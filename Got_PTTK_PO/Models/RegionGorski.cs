using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class RegionGorski
    {
        [Key]
        [Required]
        [MaxLength(5)]
        public string IdRG { get; set; }
        public string NazwaOG { get; set; }
        [ForeignKey("NazwaOG")]
        public ObszarGorski ObszarGorski { get; set; }
        public ICollection<Punkt_RegionGorski> PunktyWRegionie {get; set;}
    }
}
