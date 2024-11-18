using AutoMapper;
using BikeStoreApp.Dto;
using BikeStoreApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BikeStoreApp.AutoMapper
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            // Brand Mapping
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            // Product Mapping
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductDetailDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));
        }
    }
}


