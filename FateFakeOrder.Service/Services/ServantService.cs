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
    public class ServantService : IServantService
    {
        private readonly FFOContext _fFOContext;

        public ServantService(FFOContext fFOContext)
        {
            _fFOContext = fFOContext;
        }
        public async Task<Servant> Get(int id)
        {
            return await _fFOContext.Servants.Include(fm => fm.Familiar).SingleOrDefaultAsync(serv => serv.Id == id);
        }

        public async Task<IEnumerable<Servant>> GetServants(int masterId)
        {
            IEnumerable<Servant> servantsFromMaster = null;
            try
            {
                servantsFromMaster = await _fFOContext.Servants.Where(serv => serv.MasterId == masterId).ToListAsync();
            }
            catch(Exception ex) {
                

            }

            return servantsFromMaster;
        }


        public async Task Save(Servant servant)
        {
            await _fFOContext.Servants.AddAsync(servant);
            await _fFOContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            Servant servantToDelete = await Get(id);
            if(servantToDelete != null)
            {
                _fFOContext.Servants.Remove(servantToDelete);
                await _fFOContext.SaveChangesAsync();
            }
        }
    }
}
