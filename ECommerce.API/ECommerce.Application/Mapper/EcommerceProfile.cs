using AutoMapper;
using E_commerce.Domian;
using ECommerce.Application;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Mapper
{
    public class EcommerceProfile : Profile
    {
        public EcommerceProfile()
        {
            CreateMap<Product, AddProductDTO>().ReverseMap();
            CreateMap<Product, GetProductResponseDTO>().ReverseMap();
        }
    }
}
