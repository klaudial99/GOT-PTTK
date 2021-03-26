using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Legitymacja
    {
        [Key]
        public string NumerL { get; set; }
        public DateTime DataWaznosci { get; set; }
        public bool CzyWazna { get; set; }

        public ICollection<Legitymacja_ObszarGorski> UprawnieniaNaObszary { get; set; }
    }
}
