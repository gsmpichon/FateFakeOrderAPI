using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Services
{
    public class FamiliarService : IFamiliarService
    {
        private readonly FFOContext _dbContext;

        public FamiliarService(FFOContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task Delete(int id)
        {
            Familiar familiarToDelete = await Get(id);
            if(familiarToDelete != null)
            {
                IEnumerable<Servant> servantsToDelete = await _dbContext.Servants.Where(serv => serv.FamiliarId == familiarToDelete.Id).ToListAsync();
                foreach(Servant servantDelete in servantsToDelete)
                {
                    _dbContext.Servants.Remove(servantDelete);
                }

                _dbContext.Familiars.Remove(familiarToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Familiar> Get(int id)
        {
            return await _dbContext.Familiars.SingleOrDefaultAsync(fam => fam.Id == id);

        }

        public async Task<IEnumerable<Familiar>> GetAll()
        {
            return await _dbContext.Familiars.ToListAsync();
        }

        public Task<IEnumerable<Servant>> GetServants(int familiarID)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Familiar familiar)
        {
            Familiar familiarFromDB = await Get(familiar.Id);
            if(familiarFromDB == null)
            {
                await _dbContext.Familiars.AddAsync(familiar);
            }
            else
            {
                familiarFromDB.Name = familiar.Name;
                familiarFromDB.Class = familiar.Class;
            }
            
           
           await _dbContext.SaveChangesAsync();
        }
    }
}
