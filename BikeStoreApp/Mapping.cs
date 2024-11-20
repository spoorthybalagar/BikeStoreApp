using AutoMapper;
using BikeStoreApp.Dto;
using BikeStoreApp.Models;

namespace BikeStoreApp
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            // CreateOrderItemDto to OrderItem
            CreateMap<CreateOrderItemDto, OrderItem>();

            // UpdateOrderItemDto to OrderItem
            CreateMap<UpdateOrderItemDto, OrderItem>();

            // OrderItem to ResponseOrderItemDto
            CreateMap<OrderItem, ResponseOrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)); // Example mapping for related entity

            // UpdateOrderItemDto to ResponseOrderItemDto
            CreateMap<UpdateOrderItemDto, ResponseOrderItemDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, ResponseOrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FirstName));
        }
    }
}
