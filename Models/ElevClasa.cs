using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Grupe_Elevi.Models
{
    public class ElevClasa
    {
        public int ID { get; set; }
        public int ElevID { get; set; }
        public Elev Elev { get; set; }
        public int ClasaID { get; set; }
        public Clasa Clasa{ get; set; }
    }
}
