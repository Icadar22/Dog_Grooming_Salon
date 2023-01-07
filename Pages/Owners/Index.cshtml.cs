using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;
using System.Security.Policy;
using Dog_Grooming_Salon.Models.ViewModels;

namespace Dog_Grooming_Salon.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public IndexModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get; set; } = default!;
        public OwnerIndexData OwnerData { get; set; }
        public int OwnerID { get; set; }
        public int DogID { get; set; }
        public async Task OnGetAsync(int? id, int? dogID)
        {
            OwnerData = new OwnerIndexData();
            OwnerData.Owners = await _context.Owner
            .Include(i => i.Dogs)
            .OrderBy(i => i.LastName)
            .ToListAsync();
            if (id != null)
            {
                OwnerID = id.Value;
                Owner owner = OwnerData.Owners
                .Where(i => i.ID == id.Value).Single();
                OwnerData.Dogs = owner.Dogs;
            }

        }
    }
}
