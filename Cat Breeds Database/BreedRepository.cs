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
            _conn.Execute("UPDATE breeds SET Breed = @breed_name, Origin = @origin WHERE breed_id = @id",
             new { Breed = breed.breed_name, Origin = breed.origin, id = breed.breed_id });
        }

        Breed IBreedRepository.UpdateBreed(Breed breed)
        {
            throw new NotImplementedException();
        }
        public void AddBreed(Breed addedBreed)
        {
            _conn.Execute("INSERT INTO breeds (breed_name, origin, description, avg_lifespan) VALUES (@breed_name, @origin, @description, @avg_lifespan);",
                new { breed_name = addedBreed.breed_name, origin = addedBreed.origin, description = addedBreed.description, avg_lifespan = addedBreed.avg_lifespan });
        }
        public void DeleteBreed(Breed breed)
        {
            _conn.Execute("DELETE FROM breeds WHERE breed_id = @breed_id;", new { id = breed.breed_id });
        }
    }
}
