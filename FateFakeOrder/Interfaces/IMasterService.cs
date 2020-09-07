using FateFakeOrder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Interfaces
{
    public interface IMasterService
    {
        Task<Master> Get(int id);
        Task Save(Master master);

        Task Delete(int id);

        Task<IEnumerable<Master>> GetAll();
        Task Update();
    }
}
