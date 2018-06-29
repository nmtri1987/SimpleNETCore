using AcaraDataRequestApplication.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.MappingProfiles
{
    public class DataRequestApplicationMappingProfile : Profile
    {
        public DataRequestApplicationMappingProfile()
        {
            CreateMap<DataRequestApplicationViewModel, DataRequestApplication>();
            CreateMap<DataRequestApplication, DataRequestApplicationViewModel>();
        }
    }
}
