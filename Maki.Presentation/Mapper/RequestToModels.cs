using _1_API.Request;
using _3_Data.Models;
using AutoMapper;

namespace _1_API.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<DesignRequest, DesignDomain>();
        CreateMap<ProductRequest, Product>();
        CreateMap<CategoryRequest, Category>();
    }
    
}