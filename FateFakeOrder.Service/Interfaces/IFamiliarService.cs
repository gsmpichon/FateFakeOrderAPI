using FateFakeOrder.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface IFamiliarService
    {
        Task<IEnumerable<Familiar>> GetAll();
        Task<Familiar> Get(int id);
        Task Save(Familiar familiar);
        Task<IEnumerable<Servant>> GetServants(int familiarID);
        Task Delete(int id);
    }
}
