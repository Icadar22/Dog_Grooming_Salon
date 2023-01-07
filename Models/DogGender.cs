namespace Dog_Grooming_Salon.Models
{
    public class DogGender
    {
        public int ID { get; set; }
        public int DogID { get; set; }
        public Dog Dog { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
    }
}
