using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using MastersService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MastersService.Services
{
    public class MasterService : IMasterService
    {
        private IBaseService<Master> _dbContext;
        private readonly IBaseService<Servant> _iss;

        public MasterService(IBaseService<Master> dbContext, IBaseService<Servant> iss)
        {
            _dbContext = dbContext;
            _iss = iss;
        }

        public async Task Delete(int id)
        {
            Master masterToDelete = await Get(id);
            if (masterToDelete != null)
            {
                IEnumerable<Servant> servantsToDelete = await _iss.Get(serv => serv.MasterId == id,null,"");
                foreach (Servant servantDelete in servantsToDelete)
                {
                   await _iss.Remove(servantDelete.Id);
                }
                await _dbContext.Remove(masterToDelete.Id);
                await _dbContext.Save();
            }
        }

        public async Task<Master> Get(int id)
        {
            string include = "Servants,Servants.Familiar"; //serv => serv.Servants.Familiar
            Expression<Func<Master, bool>> filter = a => a.Id == id;

            IEnumerable<Master> masters = await _dbContext.Get(filter,null,include);
            if (masters == null || masters.Count() == 0)
                return null;
            return masters.FirstOrDefault();
        }

        public async Task<IEnumerable<Master>> GetAll()
        {
            IEnumerable<Master> masters = null;


            try
            {
                string include = "Servants,Servants.Familiar"; //serv => serv.Servants.Familiar


                masters = await _dbContext.Get(null,null,include);



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
            if (masterData == null)
            {
                await _dbContext.Add(master);
            }
            else
            {
                masterData.Name = master.Name;
                _dbContext.Update(masterData);
            }

            await _dbContext.Save();
        }

        public async Task Update()
        {
            await _dbContext.Save();

        }
    }
}
