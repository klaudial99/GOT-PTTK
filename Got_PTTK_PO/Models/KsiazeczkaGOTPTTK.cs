using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class KsiazeczkaGOTPTTK
    {
        [Key]
        public int NumerK { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public string IdUz { get; set; }
        
        public Turysta Wlasciciel { get; set; }
        public ICollection<Wycieczka> Wycieczki { get; set; }
    }
}
