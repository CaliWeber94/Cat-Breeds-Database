using Cat_Breeds_Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cat_Breeds_Database.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedRepository repo;

        public BreedController(IBreedRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var breeds = repo.GetAllBreeds();
            return View(breeds);
        }
        public IActionResult ViewBreed(int id)
        {
            var breed = repo.GetBreed(id);
            return View(breed);
        }
        public IActionResult UpdateBreed(int id)
        {
            Breed breed = repo.GetBreed(id);
            if (breed == null)
            {
                return View("BreedNotFound");
            }
            return View(breed);
        }
        public IActionResult UpdateBreedToDatabase(Breed breed)
        {
            repo.UpdateBreed(breed);

            return RedirectToAction("ViewBreed", new { id = breed.breed_id });
        }
        public IActionResult AddBreed(Breed addedBreed)
        {
            if (addedBreed == null)
            {
                return View("Breed Not Found");
            }

            return View(addedBreed);

        }
        public IActionResult InsertBreedToDatabase(Breed addedBreed)
        {
            repo.AddBreed(addedBreed);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBreed(Breed breed)
        {
            repo.DeleteBreed(breed);
            return RedirectToAction("Index");
        }
    }
}
