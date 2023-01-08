using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace Dog_Grooming_Salon.Models
{
    public class Owner
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }
        

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        


        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
       
       
        public string Email { get; set; }

        [Display(Name = "Owner Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
       
      
        public ICollection<Dog>? Dogs { get; set; }
    }
}
