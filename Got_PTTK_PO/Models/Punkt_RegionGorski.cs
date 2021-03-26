using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Punkt_RegionGorski
    {
        [Key]
        public string NazwaP { get; set; }
        [Key]
        public string IdRG { get; set; }

        public Punkt Punkt { get; set; }
        public RegionGorski RegionGorski{ get; set; }
    }
}
