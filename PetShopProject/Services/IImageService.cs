using Microsoft.AspNetCore.Http;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface IImageService
    {
        Task<string> SaveImage(string animal, IFormFile formImage);
    }
}
