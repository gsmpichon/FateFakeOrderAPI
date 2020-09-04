using FateFakeOrder.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
