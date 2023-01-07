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
    public class DetailsModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public DetailsModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

      public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog.FirstOrDefaultAsync(m => m.ID == id);
            if (dog == null)
            {
                return NotFound();
            }
            else 
            {
                Dog = dog;
            }
            return Page();
        }
    }
}
