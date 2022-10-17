using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface ICategoriesService
    {
        Task<Category> Create();
        Task<ICollection<Category>> Read();
        Task Update();
        Task Delete();
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int? id);
        Task<Category> GetCategoryByName(string name);
    }
}
