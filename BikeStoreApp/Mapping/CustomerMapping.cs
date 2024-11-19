using AutoMapper;
using BikeStoreApp.Dto;
using BikeStoreApp.Models;

namespace BikeStoreApp.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();

            
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();

            
            CreateMap<Customer, ResponseCustomerDto>().ReverseMap();

           
            
        }
    }
}
