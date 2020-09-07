using FateFakeOrder.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Interfaces
{
    public interface IServantService
    {
        Task<Servant> Get(int id);
        Task Save(Servant servant);
        Task Remove(int id);
        Task<IEnumerable<Servant>> GetServants(int masterId);

    }
}
