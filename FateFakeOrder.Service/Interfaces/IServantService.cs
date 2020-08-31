using FateFakeOrder.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface IServantService
    {
        Task Get(int id);
        Task Save(Servant servant);
        Task Remove(int id);

    }
}
