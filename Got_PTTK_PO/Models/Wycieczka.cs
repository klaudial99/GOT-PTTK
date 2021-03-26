using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Wycieczka : IValidatableObject
    {
        [Key]
        public int IdW { get; set; }
        [Required]
        public int NumerK { get; set; }
        [ForeignKey("NumerK")]
        public KsiazeczkaGOTPTTK Ksiazeczka { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRozp { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataZak { get; set; }
        public bool CzyZaliczona { get; set; }
                

        public ICollection<FragmentWycieczki> TrasyWycieczki { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataRozp > DataZak)
            {
                yield return new ValidationResult("Data rozpoczęcia nie może być późniejsza od daty zakończenia wycieczki!", new List<string> { "DataZak" });
            }
        }
    }
}
