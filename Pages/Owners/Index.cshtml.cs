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
    public class IndexModel : PageModel
    {
        private readonly Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext _context;

        public IndexModel(Dog_Grooming_Salon.Data.Dog_Grooming_SalonContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Owner != null)
            {
                Owner = await _context.Owner.ToListAsync();
            }
        }
    }
}
