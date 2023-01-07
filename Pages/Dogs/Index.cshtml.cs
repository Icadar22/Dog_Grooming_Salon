using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;

namespace Dog_Grooming_Salon.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public IndexModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get; set; } = default!;
        public DogData DogD { get; set; }
        public int DogID { get; set; }
        public int GenderID { get; set; }
        public async Task OnGetAsync(int? id, int? genderID)
        {
            DogD = new DogData();
            DogD.Dogs = await _context.Dog
            .Include(b => b.Owner)
            .Include(b => b.DogGenders)
            .ThenInclude(b => b.Gender)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                DogID = id.Value;
                Dog dog = DogD.Dogs
                .Where(i => i.ID == id.Value).Single();
                DogD.Genders = dog.DogGenders.Select(s => s.Gender);
            }
        }
    }
}
       