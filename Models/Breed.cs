namespace Dog_Grooming_Salon.Models
{
    public class Breed
    {
        public int ID { get; set; }
        public string BreedName { get; set; }

        public ICollection<Dog>? Dogs { get; set; }
    }
}
