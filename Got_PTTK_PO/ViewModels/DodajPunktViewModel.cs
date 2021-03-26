using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Got_PTTK_PO.Models;

namespace Got_PTTK_PO.ViewModels
{
    public class DodajPunktViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Nazwa punktu jest wymagana!")]
        [MaxLength(30, ErrorMessage = "Nazwa punktu musi być krótsza niż 30 znaków!")]
        public string NazwaP { get; set; }
        [Required(ErrorMessage = "Szerokość geograficzna jest wymagana!")]
        public float SzerGeo { get; set; }
        [Required(ErrorMessage = "Długość geograficzna jest wymagana!")]
        public float DlGeo { get; set; }
        public Rodzaj_Punktu Rodzaj { get; set; }
        [Required(ErrorMessage = "Wysokość npm. jest wymagana!")]
        [Range(0,4000, ErrorMessage = "Wysokość npm. musi być liczbą z przdziału ({1},{2})!")]
        public float WysNpm { get; set; }
        [Required(ErrorMessage ="Punkt musi znajdować się w regionie górskim!")]
        public ICollection<Punkt_RegionGorski> RegionyGorskie { get; set; }
        public ICollection<Punkt_TerenGorski> TerenyGorskie { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RegionyGorskie == null || RegionyGorskie.Count > 2)
            {
                yield return new ValidationResult("Regiony < 2", new List<string> { "RegionyGorskie" });
            }

            if (TerenyGorskie?.Count > 2)
            {
                yield return new ValidationResult("0 < Tereny < 2", new List<string> { "TerenyGorskie" });
            }
            if (Rodzaj!=null && TerenyGorskie==null)
            {
                yield return new ValidationResult("Punkt należy do wycieczek wielodniowych! Wybierz teren górski", new List<string> { "TerenyGorskie" });
            }
        }
    }
}
