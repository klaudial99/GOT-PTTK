using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class TerenGorski
    {
        [Key]
        [MaxLength(4)]
        public string NazwaTG { get; set; }

        public ICollection<Punkt_TerenGorski> PunktyWTerenie { get; set; }
    }
}
