using AutoMapper;
using RestaurantManagement.FoodOrdering.Models;

namespace RestaurantManagement.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodOrderDTO, FoodOrder>()
                .ReverseMap();

            CreateMap<FoodOrderDTO, Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.CustomerPhoneNumber))
                .ForMember(dest => dest.NIC, opt => opt.MapFrom(src => src.CustomerNIC))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.CustomerEmail));
        }
    }
}