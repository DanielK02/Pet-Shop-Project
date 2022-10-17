using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly PetShopDbContext _petShopDbContext;

        public AnimalService(PetShopDbContext petShopDbContext)
        {
            _petShopDbContext = petShopDbContext;
        }

        public async Task Create(Animal animal)
        {
            await _petShopDbContext.Animals.AddAsync(animal);
            await SaveChanges();
        }
        public async Task<ICollection<Animal>> Read()
        {
            return await _petShopDbContext.Animals.ToListAsync();
        }

        public async Task Update(Animal animal)
        {
            _petShopDbContext.Animals.Update(animal);
            await SaveChanges();
        }

        public async Task Delete(int? id)
        {
            var animal = await GetAnimalById(id.Value);
            _petShopDbContext.Animals.Remove(animal);
            await SaveChanges();
        }

        public async Task<Animal> GetAnimalById(int? id)
        {
            return await _petShopDbContext.Animals.FirstOrDefaultAsync(a => a.AnimalId == id.Value);
        }

        public async Task<ICollection<Animal>> GetTopTwo()
        {
            return await _petShopDbContext.Animals.OrderByDescending(a => a.Comments.Count()).Take(2).ToListAsync();
        }

        public async Task<ICollection<Animal>> GetAnimalsByCategory(int? id)
        {
            return await _petShopDbContext.Animals.Where(a => a.CategoryId == id).ToListAsync();
        }

        private async Task SaveChanges()
        {
            await _petShopDbContext.SaveChangesAsync();
        }
    }
}
