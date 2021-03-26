using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Got_PTTK_PO.Models
{
    public class Trasa
    {
        [Key]
        [MaxLength(30)]
        public string NazwaT { get; set; } = "";

        [Key]
        [MaxLength(30)]
        [Required(ErrorMessage = "Trasa musi mieć punkt początkowy!")]
        public string NazwaPP { get; set; }

        public Punkt PunktPocz { get; set; }
        [Key]
        [MaxLength(30)]
        [Required(ErrorMessage = "Trasa musi mieć punkt końcowy!")]
        public string NazwaPK { get; set; }
        public Punkt PunktKonc { get; set; }
        [Range(0, 20, ErrorMessage = "Liczba punktów musi przyjmować wartość z przdziału ({1},{2})!")]
        public int LiczbaPkt { get; set; }
        public bool CzyAktywna { get; set; }
        public ICollection<FragmentWycieczki> WycieczkiZTrasa { get; set; }

        public IEnumerable<WylaczenieTrasy> WylaczeniaTrasy { get; set; }
    }
}
