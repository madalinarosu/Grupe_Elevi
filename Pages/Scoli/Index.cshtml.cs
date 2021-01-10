using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grupe_Elevi.Data;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Pages.Scoli
{
    public class IndexModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public IndexModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        public IList<Scoala> Scoala { get;set; }

        public async Task OnGetAsync()
        {
            Scoala = await _context.Scoala.ToListAsync();
        }
    }
}
