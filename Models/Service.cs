using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Dog_Grooming_Salon.Models
{
    public class Service
    {
        public int ID { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        public ICollection<Dog>? Dogs { get; set; }
    }
}
