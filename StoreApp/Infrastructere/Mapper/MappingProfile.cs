using AutoMapper;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructere.Mapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDtoForInsertion, Product>();
        CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        CreateMap<UserDtoForCreation, IdentityUser>();
        CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
    }
}