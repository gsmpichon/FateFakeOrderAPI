using FateFakeOrder.API.Interfaces;
using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Services
{
    public class FamiliarService : IFamiliarService
    {
        private readonly IBaseService<Familiar> _dbContext;
        private readonly IBaseService<Servant> _iss;

        public FamiliarService(IBaseService<Familiar> dbContext, IBaseService<Servant> iss)
        {
            //_repository = repository;
            _dbContext = dbContext;
            _iss = iss;
        }
        public async Task Delete(int id)
        {
            Familiar familiarToDelete = await Get(id);
            if (familiarToDelete != null)
            {
                IEnumerable<Servant> servantsToDelete = await _iss.Get(serv => serv.FamiliarId == familiarToDelete.Id, null, "");
                foreach (Servant servantDelete in servantsToDelete)
                {
                    await _iss.Remove(servantDelete.Id);
                }

                await _dbContext.Remove(familiarToDelete.Id);
                await _dbContext.Save();
            }
        }

        public async Task<Familiar> Get(int id)
        {
            IEnumerable<Familiar> familiarOn = await _dbContext.Get(fam => fam.Id == id, null, "");
            if (familiarOn == null || familiarOn.Count() == 0)
                return null;
            return familiarOn.First();
        }

        public async Task<IEnumerable<Familiar>> GetAll()
        {
            return await _dbContext.Get();
        }

        public Task<IEnumerable<Servant>> GetServants(int familiarID)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Familiar familiar)
        {
            Familiar familiarFromDB = await Get(familiar.Id);
            if (familiarFromDB == null)
            {
                await _dbContext.Add(familiar);
            }
            else
            {
                _dbContext.Update(familiar);
            }


            await _dbContext.Save();
        }
    }
}
