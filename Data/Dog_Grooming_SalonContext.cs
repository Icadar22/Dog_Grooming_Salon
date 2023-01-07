using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dog_Grooming_Salon.Models;

namespace Dog_Grooming_Salon.Data
{
    public class Dog_Grooming_SalonContext : DbContext
    {
        public Dog_Grooming_SalonContext (DbContextOptions<Dog_Grooming_SalonContext> options)
            : base(options)
        {
        }

        public DbSet<Dog_Grooming_Salon.Models.Dog> Dog { get; set; } = default!;

        public DbSet<Dog_Grooming_Salon.Models.Owner> Owner { get; set; }
    }
}
