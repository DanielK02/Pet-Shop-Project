using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Models;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalService _animalRepository;
        private readonly ICategoriesService _categoriesService;
        private readonly IImageService _imageService;
        public AdminController(IAnimalService animalRepository, ICategoriesService categoriesService, ICommentsService commentsService, IImageService imageService)
        {
            _animalRepository = animalRepository;
            _categoriesService = categoriesService;
            _imageService = imageService;
        }

        [Route("admin")]
        public async Task<IActionResult> Admin(int? id) // id for category
        {
            ViewBag.Categories = await _categoriesService.GetCategories();
            if (id != null) // Refresh page by categoryid
            {
                var animalsModel = await _animalRepository.GetAnimalsByCategory(id.Value);
                return View("admin", animalsModel);
            }
            else // get all categories
            {
                var animalsModel = await _animalRepository.Read();
                return View("admin", animalsModel);
            }
        }

        public async Task<IActionResult> Create() // Go to create page
        {
            ViewBag.Categories = await _categoriesService.GetCategories();
            return View("admincreate");
        }

        [HttpPost] // After create was pressed in create page
        public async Task<IActionResult> CreatePost(Animal animal, IFormFile formFile)
        {
            if (!ModelState.IsValid) // If model is not valid return to create page
            {
                ViewBag.Categories = await _categoriesService.GetCategories();
                return View("admincreate");
            }
            else if (formFile != null) // checks if file exists
            {
                animal.ImagePath = await _imageService.SaveImage(animal.Name, formFile);
            }
            await _animalRepository.Create(animal);
            return RedirectToAction("admin");
        }


        public async Task<IActionResult> Edit(int? id) // Go to edit page
        {
            var animalModel = await _animalRepository.GetAnimalById(id.Value);
            if(animalModel == null)
            {
                return RedirectToAction("admin");
            }
            ViewBag.Categories = await _categoriesService.GetCategories();
            return View("adminedit", animalModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Animal animal, IFormFile formFile) // After edit was used
        {
            if (!ModelState.IsValid) // If invalid go to edit page again
            {
                ViewBag.Categories = await _categoriesService.GetCategories();
                return View("adminedit", animal);
            }
            else if (formFile != null)
            {
                animal.ImagePath = await _imageService.SaveImage(animal.Name, formFile);
            }
            await _animalRepository.Update(animal);
            return RedirectToAction("admin");
        }

        public async Task<IActionResult> Delete(int? id) // Deletes by id
        {
            await _animalRepository.Delete(id.Value);
            return RedirectToAction("admin");
        }
    }
}
