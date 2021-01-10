using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grupe_Elevi.Data;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Pages.Elevi
{
    public class DeleteModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public DeleteModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Elev Elev { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Elev = await _context.Elev.FirstOrDefaultAsync(m => m.ID == id);

            if (Elev == null)
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

            Elev = await _context.Elev.FindAsync(id);

            if (Elev != null)
            {
                _context.Elev.Remove(Elev);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
