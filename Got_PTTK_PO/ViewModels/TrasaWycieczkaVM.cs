using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.ViewModels
{
    public class TrasaWycieczkaVM : IValidatableObject
    {
        public string NazwaPP { get; set; }
        public string NazwaPK { get; set; }

        public int IdW { get; set; }
        public int NumerK { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataRozp { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataZak { get; set; }
        public bool CzyZaliczona { get; set; }
        public int LiczbaPkt { get; set; }
        public int NumerFW { get; set; }
        public string NazwaT { get; set; }
        public DateTime Data { get; set; }
        public string? IdUz { get; set; }
        public bool CzyZaliczony { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataRozp > DataZak)
            {
                yield return new ValidationResult("Data rozpoczęcia nie może być późniejsza od daty zakończenia wycieczki!", new List<string> { "DataZak" });
            }
        }
    }
}
