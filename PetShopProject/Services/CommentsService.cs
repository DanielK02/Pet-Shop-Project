using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly PetShopDbContext _petShopDbContext;

        public CommentsService(PetShopDbContext petShopDbContext)
        {
            _petShopDbContext = petShopDbContext;
        }
        public async Task Create(string comment, int animalId)
        {
            await _petShopDbContext.Comments.AddAsync(new Comments { AnimalId = animalId, Comment = comment });
            await SaveChanges();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comments>> Read()
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        private async Task SaveChanges()
        {
            await _petShopDbContext.SaveChangesAsync();
        }
    }
}
