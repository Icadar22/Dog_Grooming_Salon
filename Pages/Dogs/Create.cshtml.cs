using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;

namespace Dog_Grooming_Salon.Pages.Dogs
{
    public class CreateModel : DogGenderModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public CreateModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID", "FullName");
            ViewData["BreedID"] = new SelectList(_context.Set<Breed>(), "ID", "BreedName");
            ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ID", "ServiceName");

            var dog = new Dog();
            dog.DogGenders = new List<DogGender>();
            PopulateAssignedGenderData(_context, dog);

            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenders)
        {
            var newDog = new Dog();
            if (selectedGenders != null)
            {
                newDog.DogGenders = new List<DogGender>();
                foreach (var cat in selectedGenders)
                {
                    var catToAdd = new DogGender
                    {
                        GenderID = int.Parse(cat)
                    };
                    newDog.DogGenders.Add(catToAdd);
                }
            }
            Dog.DogGenders = newDog.DogGenders;
            _context.Dog.Add(Dog);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedGenderData(_context, newDog);
            return Page();
        }
    }
}



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

