using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Grupe_Elevi.Data;
using System.Threading.Tasks;




namespace Grupe_Elevi.Models
{
    public class ElevClasePageModels : PageModel
    {

        public List<AssignedClasaData> AssignedClasaDataList;
        public void PopulateAssignedClasaData(Grupe_EleviContext context,
        Elev elev)
        {
            var allClase = context.Clasa;
            var elevClase = new HashSet<int>(
            elev.ElevClase.Select(c => c.ElevID));
            AssignedClasaDataList = new List<AssignedClasaData>();
            foreach (var cls in allClase)
            {
                AssignedClasaDataList.Add(new AssignedClasaData
                {
                    ClasaID = cls.ID,
                    NumeClasa = cls.NumeClasa,
                    Assigned = elevClase.Contains(cls.ID)
                });
            }
        }
        public void UpdateElevClase(Grupe_EleviContext context,
        string[] selectedClase, Elev elevToUpdate)
        {
            if (selectedClase == null)
            {
                elevToUpdate.ElevClase = new List<ElevClasa>();
                return;
            }
            var selectedClaseHS = new HashSet<string>(selectedClase);
            var elevClase = new HashSet<int>
            (elevToUpdate.ElevClase.Select(c => c.Clasa.ID));
            foreach (var cls in context.Clasa)
            {
                if (selectedClaseHS.Contains(cls.ID.ToString()))
                {
                    if (!elevClase.Contains(cls.ID))
                    {
                        elevToUpdate.ElevClase.Add(
                        new ElevClasa
                        {
                            ElevID = elevToUpdate.ID,
                            ClasaID = cls.ID
                        });
                    }
                }
                else
                {
                    if (elevClase.Contains(cls.ID))
                    {
                        ElevClasa courseToRemove
                        = elevToUpdate
                        .ElevClase
                        .SingleOrDefault(i => i.ClasaID == cls.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}


