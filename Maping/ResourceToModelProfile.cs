using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication3.Domain.Models;
using WebApplication3.Resources;

namespace WebApplication3.Maping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCompanyResource, Company>();

            CreateMap<AuthUserResource, User>();
        }
    }
}
