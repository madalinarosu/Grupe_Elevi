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
    public class DetailsModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public DetailsModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        public Scoala Scoala { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scoala = await _context.Scoala.FirstOrDefaultAsync(m => m.ID == id);

            if (Scoala == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
