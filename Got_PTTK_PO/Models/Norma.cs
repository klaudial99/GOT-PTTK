using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Norma
    {
        [Key]
        public int IdO { get; set; }
        [ForeignKey("IdO")]
        public Odznaka Odznaka { get; set; }
        [Key]
        public int NumerN { get; set; }
        [Required]
        public int WymagPkt { get; set; }

        public ICollection<Norma_Sezon> SezonyZNorma { get; set; }
    }
}
