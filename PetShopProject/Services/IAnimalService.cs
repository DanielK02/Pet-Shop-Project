using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface IAnimalService
    {
        Task Create(Animal animal);
        Task<ICollection<Animal>> Read();
        Task Delete(int? id);
        Task Update(Animal animal);
        Task<ICollection<Animal>> GetTopTwo();
        Task<Animal> GetAnimalById(int? id);
        Task<ICollection<Animal>> GetAnimalsByCategory(int? id);
    }
}
