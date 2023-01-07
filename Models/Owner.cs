using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dog_Grooming_Salon.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Owner Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Dog>? Dogs { get; set; }
    }
}
