using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class ObszarGorski
    {
        [Required]
        [Key]
        [MaxLength(20)]
        public string NazwaOG { get; set; }

        public ICollection<RegionGorski> RegionyGorskie { get; set; }

        public ICollection<Legitymacja_ObszarGorski> LegitymacjeNaObszar { get; set; }
    }
}
