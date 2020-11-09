using JustDoIt.Models;
using JustDoIt.Models.AuxiliaryModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDoIt.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserModel>();
            CreateMap<RegisterModel, Users>();
            CreateMap<UpdateModel, Users>();
        }
    }
}
