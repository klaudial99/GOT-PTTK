using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class FragmentWycieczki
    {
        [Key]
        [Required]
        public int NumerFW { get; set; }
        [Key]
        [Required]
        public int IdW { get; set; }

        [Required]
        [MaxLength(30)]
        public string NazwaT { get; set; }
        [Required]
        [MaxLength(30)]
        public string NazwaPP { get; set; }
        [Required]
        [MaxLength(30)]
        public string NazwaPK { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Data { get; set; }
        public string? IdUz { get; set; }
        [ForeignKey("IdUz")]
        public EkspertGorski Potwierdzajacy { get; set; }
        [Required]
        public bool CzyZaliczony { get; set; }

        public bool DoZaliczenia { get; set; }
        [MaxLength(300)]
        public string PowodOdrzucenia { get; set; }
        [MaxLength(100)]
        public string ZdjecieDowod { get; set; }

        [ForeignKey("NazwaT, NazwaPP, NazwaPK")]
        public Trasa Trasa { get; set; }
        [ForeignKey("IdW")]
        public Wycieczka Wycieczka { get; set; }


    }
}
