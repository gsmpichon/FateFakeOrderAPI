using FateFakeOrder.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface IMasterService
    {
        Task<Master> Get(int id);
        Task Save(Master master);

        Task Delete(int id);
    }
}
