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
    public class MasterService : IMasterService
    {
        private readonly FFOContext dbContext;

        public MasterService(FFOContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Master> Get(int id)
        {
            return await this.dbContext.Masters.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(Master master)
        {
            var masterData = await Get(master.Id); // use the same get method 
            if(masterData == null)
            {
                await this.dbContext.Masters.AddAsync(master);
            }
            else
            {
                masterData.Name = master.Name;
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
