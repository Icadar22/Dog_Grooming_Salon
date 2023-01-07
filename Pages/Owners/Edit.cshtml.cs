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

namespace Dog_Grooming_Salon.Pages.Owners
{
    public class EditModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public EditModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }

            var owner =  await _context.Owner.FirstOrDefaultAsync(m => m.ID == id);
            if (owner == null)
            {
                return NotFound();
            }
            Owner = owner;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(Owner.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OwnerExists(int id)
        {
          return _context.Owner.Any(e => e.ID == id);
        }
    }
}
