using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Norma_Sezon
    {
        [Key]
        public int IdS { get; set; }
        public Sezon Sezon { get; set; }
        [Key]
        public int IdO { get; set; }
        [Key]
        public int NumerN { get; set; }
        [ForeignKey("IdO, NumerN")]
        public Norma Norma { get; set; }

        public bool Aktualna { get; set; }
        public int Punkty { get; set; }
    }
}
