using Microsoft.AspNetCore.Mvc;
using PetShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService _animals;
        public HomeController(IAnimalService animals)
        {
            _animals = animals;
        }
        public async Task<IActionResult> Index()
        {
            var animalList = await _animals.GetTopTwo();
            return View(animalList);
        }
    }
}
