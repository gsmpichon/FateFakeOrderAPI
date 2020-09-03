using FateFakeOrder.Data;
using FateFakeOrder.Model.Models;
using FateFakeOrder.Service.Interfaces;
using FateFakeOrder.Service.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Services
{
    public class MasterService : IMasterService
    {
        private readonly FFOContext _dbContext;
        private readonly IServantService _iss;

        public MasterService(FFOContext dbContext,IServantService iss)
        {
            _dbContext = dbContext;
            _iss = iss;
        }

        public async Task Delete(int id)
        {
            Master masterToDelete = await Get(id);
            if(masterToDelete != null)
            {
                IEnumerable<Servant> servantsToDelete = _dbContext.Servants.Where(serv => serv.MasterId == id);
                foreach(Servant servantDelete in servantsToDelete)
                {
                    _dbContext.Servants.Remove(servantDelete);
                }
                _dbContext.Masters.Remove(masterToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Master> Get(int id)
        {
            return await _dbContext.Masters.Include(serv => serv.Servants).Include("Servants.Familiar").SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Master>> GetAll()
        {
            IEnumerable<Master> masters = null;


            try
            {

                masters = await _dbContext.Masters.Include(serv => serv.Servants).Include("Servants.Familiar").ToListAsync();

             

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return masters;
        }

        public async Task Save(Master master)
        {
            var masterData = await Get(master.Id); // use the same get method 
            if(masterData == null)
            {
                await _dbContext.Masters.AddAsync(master);
            }
            else
            {
                masterData.Name = master.Name;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
