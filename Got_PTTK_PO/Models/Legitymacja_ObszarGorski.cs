using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Legitymacja_ObszarGorski
    {
        [Key]
        public string NumerL { get; set; }
        [ForeignKey("NumerL")]
        public Legitymacja Legitymacja { get; set; }
        [Key]
        public string NazwaOG { get; set; }
        [ForeignKey("NazwaOG")]
        public ObszarGorski ObszarGorski {get; set;}
    }
}
