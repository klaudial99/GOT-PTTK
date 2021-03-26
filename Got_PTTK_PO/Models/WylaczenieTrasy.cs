using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class WylaczenieTrasy
    {
        [Key]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DataPocz { get; set; }

        [Required]
        [MaxLength(30)]
        public string NazwaT { get; set; }
        [Required]
        [MaxLength(30)]
        public string NazwaPP { get; set; }
        [Required]
        [MaxLength(30)]
        public string NazwaPK { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DataKonc { get; set; }

        [ForeignKey("NazwaT, NazwaPP, NazwaPK")]
        public Trasa Trasa { get; set; }
    }
}
