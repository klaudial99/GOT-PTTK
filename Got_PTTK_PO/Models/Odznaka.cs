using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Odznaka
    {
        [Key]
        public int IdO { get; set; }
        [Required]
        [MaxLength(20)]
        public string Rodzaj { get; set; }
        [Required]
        [MaxLength(20)]
        public string Stopien { get; set; }

        public ICollection<Norma> Normy { get; set; }
    }
}
