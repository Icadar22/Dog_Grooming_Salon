namespace Dog_Grooming_Salon.Models
{
    public class DogData
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<DogGender> DogGenders { get; set; }
    }
}
