using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Turysta
    {
        [Key]
        public string IdUz { get; set; }
        [ForeignKey("IdUz")]
        public IdentityUser User { get; set; }
        [MaxLength(30)]
        [Required]
        public string Imie { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public DateTime DataUrodzenia { get; set; }
        [MaxLength(12)]
        public string NrTel { get; set; }
        [Required]
        public bool CzyDziecko { get; set; }

        public int? NumerK { get; set; }
        [ForeignKey("NumerK")]
        public KsiazeczkaGOTPTTK Ksiazeczka { get; set; }
        [Required]
        public int IdA { get; set; }
        [ForeignKey("IdA")]
        public Adres AdresZamieszkania { get; set; }

    }
}
