using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FateFakeOrder.Data;
using FateFakeOrder.Data.Models;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FateFakeOrder.Service.Services
{
    public class UserService : IUserService
    {
        private readonly FFOContext _dbContext;

        public UserService(FFOContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _dbContext.FFOUsers.ToListAsync();
            return users;
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUsernamePassword(string username, string password)
        {
            User userFromDb = await _dbContext.FFOUsers.Where(u => u.Username == username).SingleOrDefaultAsync();
            return userFromDb;
        }

        public Task Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
