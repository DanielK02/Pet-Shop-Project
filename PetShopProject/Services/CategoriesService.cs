using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly PetShopDbContext _petShopDbContext;
        public CategoriesService(PetShopDbContext petShopDbContext)
        {
            _petShopDbContext = petShopDbContext;
        }

        public Task<Category> Create()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Category>> Read()
        {
            throw new NotImplementedException();
        }
        public Task Update()
        {
            throw new NotImplementedException();
        }
        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories() //Read
        {
            return await _petShopDbContext.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int? id)
        {
            return await _petShopDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id.Value);
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            return await _petShopDbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

    }
}
