using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalService _animalRepository;
        private readonly ICategoriesService _categoriesService;
        private readonly ICommentsService _commentsService;

        public CatalogController(IAnimalService animalRepository, ICategoriesService categoriesService, ICommentsService commentsService)
        {
            _animalRepository = animalRepository;
            _categoriesService = categoriesService;
            _commentsService = commentsService;
        }

        [Route("catalog")]
        public async Task<IActionResult> Catalog(int? id) // Get all animals
        {
            ViewBag.Categories = await _categoriesService.GetCategories();
            if (id != null) // Refreshes page by CategoryId
            {
                var animalsModel = await _animalRepository.GetAnimalsByCategory(id.Value);
                return View(animalsModel);
            }
            else // Get all animals
            {
                var animalsModel = await _animalRepository.Read();
                return View(animalsModel);
            }
        }

        public async Task<IActionResult> Animal(int? id, string commentText)
        {
            if (commentText != null) // From Animal page
                await _commentsService.Create(commentText, id.Value);

            var animalModel = await _animalRepository.GetAnimalById(id.Value);
            if (animalModel != null) // Make sure Animal exists to get it's CategoryId for the Animal page
            {
                ViewBag.Categories = await _categoriesService.GetCategoryById(animalModel.CategoryId);
                return View(animalModel);
            }
            // If not, go back to catalog
            return RedirectToAction("catalog");
        }

    }
}
