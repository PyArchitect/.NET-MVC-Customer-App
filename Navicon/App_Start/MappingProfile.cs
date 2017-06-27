using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Navicon.Models;
using Navicon.Dtos;

namespace Navicon.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer >();
        }
    }
}