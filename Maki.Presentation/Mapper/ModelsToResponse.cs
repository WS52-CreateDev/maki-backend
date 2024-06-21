using _1_API.Response;
using _3_Data;
using _3_Data.Models;
using AutoMapper;

namespace _1_API.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse()
    {
        CreateMap<DesignData, DesignResponse>();
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));;
        CreateMap<Category, CategoryResponse>();
    }
}