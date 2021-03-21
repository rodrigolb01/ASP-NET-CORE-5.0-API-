using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;
using WebApplication3.Resources;
using WebApplication3.Domain.Helpers;
using AutoMapper;
using WebApplication3.Extensions;

namespace WebApplication3.Maping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Company, CompanyResource>();
            CreateMap<User, UserResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Purchase, PurchaseResource>()
                .ForMember(p => p.Status, opt => opt.MapFrom(p => p.Status.ToDescriptionString()))
                .ForMember(p => p.PaymentMethod, opt => opt.MapFrom(p => p.PaymentMethod.ToDescriptionString()));

        }
    }
}
