using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;
using Microsoft.Data.SqlClient;

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

        public string AppointmentDateSort { get; set; }
        public string NameSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? genderID, string sortOrder, string
searchString)
        {
            DogD = new DogData();

            AppointmentDateSort = String.IsNullOrEmpty(sortOrder) ? "appointmentdate_desc" : "";
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            DogD.Dogs = await _context.Dog
            .Include(b => b.Owner)
            .Include(b => b.Service)
            .Include(b => b.Breed)
            .Include(b => b.DogGenders)
            .ThenInclude(b => b.Gender)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                DogD.Dogs = DogD.Dogs.Where(s => s.Owner.FirstName.Contains(searchString)
                || s.Owner.LastName.Contains(searchString)
                || s.Name.Contains(searchString));

            }

                if (id != null)
            {
                DogID = id.Value;
                Dog dog = DogD.Dogs
                .Where(i => i.ID == id.Value).Single();
                DogD.Genders = dog.DogGenders.Select(s => s.Gender);
            }

            switch (sortOrder)
            {
                case "appointmentdate_desc":
                    DogD.Dogs = DogD.Dogs.OrderByDescending(s =>
                    s.AppointmentDate);
                    break;
                case "name_desc":
                    DogD.Dogs = DogD.Dogs.OrderByDescending(s =>
                    s.Name);
                    break;
            }
        }
    }
}
       