using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.ViewModels
{
    public class TworzenieTrasyVM
    {
        [MaxLength(30)]
        public string NazwaT { get; set; } = "";
        [MaxLength(30)]
        [Required(ErrorMessage = "Trasa musi mieć punkt początkowy!")]
        public string NazwaPP { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Trasa musi mieć punkt końcowy!")]
        public string NazwaPK { get; set; }
        [Required(ErrorMessage = "Trasa musi mieć ustalona liczbę punktów!")]
        [Range(0, 20, ErrorMessage = "Liczba punktów musi przyjmować wartość z przdziału ({1},{2})!")]
        public int LiczbaPkt { get; set; }
        public bool CzyAktywna { get; set; }
    }
}
