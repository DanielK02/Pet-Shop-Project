using PetShopProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public interface ICommentsService
    {
        Task Create(string comment, int animalId);
        Task<ICollection<Comments>> Read();
        Task Update();
        Task Delete();
    }
}