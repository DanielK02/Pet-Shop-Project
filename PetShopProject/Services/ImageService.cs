using Microsoft.AspNetCore.Http;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImage(string animal, IFormFile formImage)
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                formImage.OpenReadStream().CopyTo(ms);
                bytes = ms.ToArray();
            }
            await File.WriteAllBytesAsync($"wwwroot//{animal}.jpg", bytes);

            return $"/{animal}.jpg";
        }
    }
}
