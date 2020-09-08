using AutoMapper;
using FateFakeOrder.Data;
using FateFakeOrder.Model.Models;
using FateFakeOrder.Model.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Profiles
{
    public class MastersProfile : Profile
    {
        public MastersProfile()
        {
            CreateMap<Master, MasterCreateModel>();
            CreateMap<MasterCreateModel, Master>();

            CreateMap<Master, MasterUpdateModel>();

        }
    }
}
