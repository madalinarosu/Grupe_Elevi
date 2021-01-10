using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Data
{
    public class Grupe_EleviContext : DbContext
    {
        public Grupe_EleviContext (DbContextOptions<Grupe_EleviContext> options)
            : base(options)
        {
        }

        public DbSet<Grupe_Elevi.Models.Elev> Elev { get; set; }

        public DbSet<Grupe_Elevi.Models.Scoala> Scoala { get; set; }

        public DbSet<Grupe_Elevi.Models.Clasa> Clasa { get; set; }
    }
}
