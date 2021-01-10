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
    public class DeleteModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public DeleteModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scoala = await _context.Scoala.FindAsync(id);

            if (Scoala != null)
            {
                _context.Scoala.Remove(Scoala);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
