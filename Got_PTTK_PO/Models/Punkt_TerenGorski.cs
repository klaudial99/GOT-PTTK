using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Punkt_TerenGorski
    {
        [Key]
        public string NazwaP { get; set; }
        [Key]
        public string NazwaTG { get; set; }

        public Punkt Punkt { get; set; }
        public TerenGorski TerenGorski { get; set; }
    }
}
