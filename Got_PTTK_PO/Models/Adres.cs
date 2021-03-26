using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Adres
    {
        [Key]
        public int IdA { get; set; }
        [MaxLength(30)]
        public string Ulica { get; set; }
        [MaxLength(5)]
        public string NrDomu { get; set; }
        [MaxLength(5)]
        public string NrMieszkania { get; set; }
        [MaxLength(6)]
        public string KodPocztowy { get; set; }
        [MaxLength(30)]
        public string Miasto { get; set; }
        [MaxLength(30)]
        public string Kraj { get; set; }
        public IEnumerable<Turysta> Turysci { get; set; }
        public IEnumerable<EkspertGorski> Eksperci { get; set; }
    }
}
