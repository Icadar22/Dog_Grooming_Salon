using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;

namespace Dog_Grooming_Salon.Pages.Dogs
{
    public class EditModel : DogGenderModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public EditModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog
.Include(b => b.Owner)
.Include(b => b.DogGenders).ThenInclude(b => b.Gender)
.AsNoTracking()
.FirstOrDefaultAsync(m => m.ID == id);


            if (Dog == null)
            {
                return NotFound();
            }

            PopulateAssignedGenderData(_context, Dog);


            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID","FullName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedGenders)
        {
            if (id == null)
              {
                 return NotFound();
              }

            var dogToUpdate = await _context.Dog
.Include(i => i.Owner)
.Include(i => i.DogGenders)
.ThenInclude(i => i.Gender)
.FirstOrDefaultAsync(s => s.ID == id);
            if (dogToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Dog>(
dogToUpdate,
"Dog",
i => i.Name, i => i.Owner,
i => i.Age, i => i.AppointmentDate, i => i.AppointmentHour))
            {
                UpdateDogGenders(_context, selectedGenders, dogToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateDogGenders(_context, selectedGenders, dogToUpdate);
            PopulateAssignedGenderData(_context, dogToUpdate);
            return Page();
        }
    }
}
