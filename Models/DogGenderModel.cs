using Microsoft.AspNetCore.Mvc.RazorPages;
using Dog_Grooming_Salon.Data;


namespace Dog_Grooming_Salon.Models
{
    public class DogGenderModel : PageModel
    {
        public List<AssignedGenderData> AssignedGenderDataList;

        public void PopulateAssignedGenderData(Dog_Grooming_SalonContext context, Dog dog)
        {
            var allGenders = context.Gender;
            var dogGenders = new HashSet<int>(
            dog.DogGenders.Select(c => c.GenderID));

            AssignedGenderDataList = new List<AssignedGenderData>();
            foreach (var cat in allGenders)
            {
                AssignedGenderDataList.Add(new AssignedGenderData
                {
                    GenderID = cat.ID,
                    Name = cat.GenderName,
                    Assigned = dogGenders.Contains(cat.ID)
                });
            }
        }

        public void UpdateDogGenders(Dog_Grooming_SalonContext context,
string[] selectedGenders, Dog dogToUpdate)
        {
            if (selectedGenders == null)
            {
                dogToUpdate.DogGenders = new List<DogGender>();
                return;
            }

            var selectedGendersHS = new HashSet<string>(selectedGenders);
            var dogGenders = new HashSet<int>
            (dogToUpdate.DogGenders.Select(c => c.Gender.ID));
            foreach (var cat in context.Gender)
            {
                if (selectedGendersHS.Contains(cat.ID.ToString()))
                {
                    if (!dogGenders.Contains(cat.ID))
                    {
                        dogToUpdate.DogGenders.Add(
                        new DogGender
                        {
                            DogID = dogToUpdate.ID,
                            GenderID = cat.ID
                        });
                    }
                }
                else
                {
                    if (dogGenders.Contains(cat.ID))
                    {
                        DogGender courseToRemove
                        = dogToUpdate
                        .DogGenders
                        .SingleOrDefault(i => i.GenderID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
