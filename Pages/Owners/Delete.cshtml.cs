using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Data;
using Dog_Grooming_Salon.Models;

namespace Dog_Grooming_Salon.Pages.Owners
{
    public class DeleteModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public DeleteModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner.FirstOrDefaultAsync(m => m.ID == id);

            if (owner == null)
            {
                return NotFound();
            }
            else 
            {
                Owner = owner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }
            var owner = await _context.Owner.FindAsync(id);

            if (owner != null)
            {
                Owner = owner;
                _context.Owner.Remove(Owner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
