using Cat_Breeds_Database.Models;

namespace Cat_Breeds_Database
{
    public interface IBreedRepository
    {
        public IEnumerable<Breed> GetAllBreeds();

        public Breed GetBreed(int id);

        public Breed UpdateBreed(Breed breed);

        public void AddBreed(Breed addedBreed);

        public void DeleteBreed(Breed breed);
    }
   
}
