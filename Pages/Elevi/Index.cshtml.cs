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
    public class IndexModel : PageModel
    {
        private readonly Grupe_Elevi.Data.Grupe_EleviContext _context;

        public IndexModel(Grupe_Elevi.Data.Grupe_EleviContext context)
        {
            _context = context;
        }
        public IList<Elev> Elev { get; set; }
        public ElevData ElevD { get; set; }
        public int ElevID { get; set; }
        public int ClasaID { get; set; }
        public async Task OnGetAsync(int? id, int? clasaID)
        {
            ElevD = new ElevData();

            ElevD.Elevi = await _context.Elev
            .Include(b => b.Scoala)
            .Include(b => b.ElevClase)
            .ThenInclude(b => b.Clasa)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                ElevID = id.Value;
                Elev elev = ElevD.Elevi
                .Where(i => i.ID == id.Value).Single();
                ElevD.Clase = elev.ElevClase.Select(s => s.Clasa);
            }
        }
    }
}
