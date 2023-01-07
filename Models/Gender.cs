namespace Dog_Grooming_Salon.Models
{
    public class Gender
    {
        public int ID { get; set; }
        public string GenderName { get; set; }
        public ICollection<DogGender>? DogGenders { get; set; }
    }
}
