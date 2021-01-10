using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupe_Elevi.Data;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Pages.Elevi
{
    public class EditModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public EditModel(Grupe_Elevi.Data.Grupe_EleviContext context)
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

            Elev = await _context.Elev
                    .Include(b => b.Scoala)
                    .Include(b => b.ElevClase).ThenInclude(b => b.Clasa)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);


            if (Elev == null)
            {
                return NotFound();
            }
            PopulateAssignedClasaData(_context, Elev);
            ViewData["ScoalaID"] = new SelectList(_context.Set<Scoala>(), "ID", "DenumireScoala");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedClase)
        {
            if (id == null)
            {
                return NotFound();
            }
            var elevToUpdate = await _context.Elev
                .Include(i => i.Scoala)
                .Include(i => i.ElevClase)
                .ThenInclude(i => i.Clasa)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (elevToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Elev>(
                elevToUpdate,
                 "Elev",
                 i => i.Nume, i => i.Prenume,
                 i => i.CNP, i => i.DataNasterii, i => i.Scoala))
            {
                UpdateElevClase(_context, selectedClase, elevToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

                UpdateElevClase(_context, selectedClase, elevToUpdate);
                PopulateAssignedClasaData(_context, elevToUpdate);
                return Page();
            
        }
        private void UpdateElevClase(Grupe_EleviContext context, string[] selectedClase, Elev elevToUpdate)
        {
            throw new NotImplementedException();
        }

        private void PopulateAssignedClasaData(Grupe_EleviContext context, Elev elevToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

