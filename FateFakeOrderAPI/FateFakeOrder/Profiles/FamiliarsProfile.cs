using AutoMapper;
using FateFakeOrder.Data;
using FateFakeOrder.Model.Models.Familiar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Profiles
{
    public class FamiliarsProfile : Profile
    {

        public FamiliarsProfile()
        {
            CreateMap<Familiar, FamiliarCreateModel>();
            CreateMap<FamiliarCreateModel, Familiar>();
            CreateMap<Familiar, FamiliarReadModel>();
            CreateMap<FamiliarReadModel, Familiar>();


        }
    }
}
