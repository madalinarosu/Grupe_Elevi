using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Grupe_Elevi.Models
{
    public class Scoala
    {
        public int ID { get; set; }
        public string DenumireScoala { get; set; }
        public ICollection<Elev> Elevi { get; set; }
    }
}
