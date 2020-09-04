using FateFakeOrder.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> GetByUsernamePassword(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task Save(User user);
        Task Delete(int id);
    }
}