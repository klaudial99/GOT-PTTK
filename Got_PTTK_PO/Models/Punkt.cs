using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models 
{
    public enum Rodzaj_Punktu
    {
        Początkowy = 0,
        Pośredni = 1,
        Końcowy = 2
    }
    public class Punkt
    {
        [Required]
        [Key]
        [MaxLength(30)]
        public string NazwaP { get; set; }
        [Required]
        public float SzerGeo { get; set; }
        [Required]
        public float DlGeo { get; set; }
        public Rodzaj_Punktu Rodzaj { get; set; }

        public float WysNpm { get; set; }
        public ICollection<Punkt_RegionGorski> RegionyGorskie { get; set; }
        public ICollection<Punkt_TerenGorski> TerenyGorskie { get; set; }

        public ICollection<Trasa> TrasyRozpoczynane { get; set; }
        public ICollection<Trasa> TrasyKonczone { get; set; }
    

}
}
