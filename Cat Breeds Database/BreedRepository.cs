using Cat_Breeds_Database.Models;
using Dapper;
using System.Data;

namespace Cat_Breeds_Database
{
    public class BreedRepository : IBreedRepository
    {
        private readonly IDbConnection _conn;
        public BreedRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Breed> GetAllBreeds()
        {
            return _conn.Query<Breed>("SELECT * FROM breeds;");

        }
        public Breed GetBreed(int id)
        {
            return _conn.QuerySingle<Breed>("SELECT * FROM BREEDS WHERE breed_id = @id", new { id = id });
        }
        public void UpdateBreed(Breed breed)
        {
            _conn.Execute("UPDATE breeds SET breed_name = @breed_name, origin = @origin, avg_lifespan = @avg_lifespan, image = @image, description = @description WHERE breed_id = @id",
             new { breed_name = breed.breed_name, origin = breed.origin, description = breed.description, avg_lifespan = breed.avg_lifespan, image = breed.image,  id = breed.breed_id });
        }

       
        public void AddBreed(Breed addedBreed)
        {
            _conn.Execute("INSERT INTO breeds (breed_name, origin, description, avg_lifespan, image) VALUES (@breed_name, @origin, @description, @avg_lifespan, @image);",
                new { breed_name = addedBreed.breed_name, origin = addedBreed.origin, description = addedBreed.description, avg_lifespan = addedBreed.avg_lifespan, image = addedBreed.image });
        }
        public void DeleteBreed(Breed breed)
        {
            _conn.Execute("DELETE FROM breeds WHERE breed_id = @breed_id;", new { breed_id = breed.breed_id });
        }
    }
}
