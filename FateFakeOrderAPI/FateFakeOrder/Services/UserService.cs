using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateFakeOrder.API.Interfaces;
using FateFakeOrder.Data;
using FateFakeOrder.Data.Models;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FateFakeOrder.API.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService<User> _dbContext;

        public UserService(IBaseService<User> dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _dbContext.Get();
            return users;
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUsernamePassword(string username, string password)
        {
            IEnumerable<User> userFromDb = await _dbContext.Get(u => u.Username == username, null, "");
            if (userFromDb == null)
                return null;
            return userFromDb.FirstOrDefault();
        }

        public Task Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
