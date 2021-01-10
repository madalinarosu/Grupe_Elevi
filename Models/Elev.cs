using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;


namespace Grupe_Elevi.Models
{
    public class Elev
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Completati Numele!"), Required, StringLength(50,
      MinimumLength = 3)]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Completati Prenumele"), Required, StringLength(50,
       MinimumLength = 3)]
        public string Prenume { get; set; }
        
        [Column(TypeName = "nvarchar(16)")]
        public string CNP { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        public int ScoalaID { get; set; }
        public Scoala Scoala { get; set; }

        public ICollection<ElevClasa> ElevClase { get; set; }
    }
}
