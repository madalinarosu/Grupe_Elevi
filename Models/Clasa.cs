using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Grupe_Elevi.Models
{
    public class Clasa
    {
        public int ID { get; set; }
        public string NumeClasa { get; set; }

        public ICollection<ElevClasa> ClaseElevi { get; set; }
    }
}
