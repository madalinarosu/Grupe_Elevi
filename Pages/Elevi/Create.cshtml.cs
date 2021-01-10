using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grupe_Elevi.Data;
using Grupe_Elevi.Models;

namespace Grupe_Elevi.Pages.Elevi
{
    public class CreateModel : ElevClasePageModels
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public CreateModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ScoalaID"] = new SelectList(_context.Set<Scoala>(), "ID", "DenumireScoala");
            var elev = new Elev();
            elev.ElevClase = new List<ElevClasa>();
            PopulateAssignedClasaData(_context, elev);


            return Page();
        }

        [BindProperty]
        public Elev Elev { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedClase)
        {
            var newElev = new Elev();
            if (selectedClase != null)
            {
                newElev.ElevClase = new List<ElevClasa>();
                foreach (var cls in selectedClase)
                {
                    var clsToAdd = new ElevClasa
                    {
                        ClasaID = int.Parse(cls)
                    };
                    newElev.ElevClase.Add(clsToAdd);
                }
            }
            if (await TryUpdateModelAsync<Elev>(
            newElev,
            "Elev",
            i => i.Nume, i => i.Prenume,
            i => i.CNP, i => i.DataNasterii, i => i.ScoalaID))
            {
                _context.Elev.Add(newElev);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedClasaData(_context, newElev);
            return Page();
        }
    }
}