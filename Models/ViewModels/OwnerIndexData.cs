using System.Security.Policy;

namespace Dog_Grooming_Salon.Models.ViewModels
{
    public class OwnerIndexData
    {
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Dog> Dogs { get; set; }
    }
}
