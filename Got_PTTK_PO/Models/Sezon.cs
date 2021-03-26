using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Sezon
    {
        [Key]
        public int IdS { get; set; }
        public int NumerK { get; set; }
        [ForeignKey("NumerK")]
        public KsiazeczkaGOTPTTK Ksiazeczka { get; set; }
        [Required]
        public int Rok { get; set; }
        [Required]
        public int Punkty { get; set; }
        [Required]
        public int Nadwyzka { get; set; }

        public ICollection<Norma_Sezon> NormyWSezonie { get; set; }
    }
}
