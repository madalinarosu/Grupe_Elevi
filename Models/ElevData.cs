using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Grupe_Elevi.Models
{
    public class ElevData
    {
        public IEnumerable<Elev> Elevi { get; set; }
        public IEnumerable<Clasa> Clase { get; set; }
        public IEnumerable<ElevClasa> ElevClase{ get; set; }

    }
}
