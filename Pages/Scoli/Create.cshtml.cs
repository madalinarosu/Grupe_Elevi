using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grupe_Elevi.Data;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Pages.Scoli
{
    public class CreateModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public CreateModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scoala Scoala { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scoala.Add(Scoala);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
