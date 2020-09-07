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
    public class ServantService : IServantService
    {
        private readonly IBaseService<Servant> _dbSet;

        public ServantService(IBaseService<Servant> dbSet)
        {
            //_repository = repository;
            _dbSet = dbSet;
        }
        public async Task<Servant> Get(int id)
        {
            IEnumerable<Servant> servants = await _dbSet.Get(serv => serv.Id == id, null, "Familiar");
            if (servants == null || servants.Count() == 0)
                return null;
            return servants.First();
        }

        public async Task<IEnumerable<Servant>> GetServants(int masterId)
        {
            IEnumerable<Servant> servantsFromMaster = null;
            try
            {
                servantsFromMaster = await _dbSet.Get(serv => serv.MasterId == masterId, null, "Familiar");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return servantsFromMaster;
        }


        public async Task Save(Servant servant)
        {
            await _dbSet.Add(servant);
            await _dbSet.Save();
        }

        public async Task Remove(int id)
        {
            Servant servantToDelete = await Get(id);
            if (servantToDelete != null)
            {
                await _dbSet.Remove(servantToDelete.Id);
                await _dbSet.Save();
            }
        }
    }
}
