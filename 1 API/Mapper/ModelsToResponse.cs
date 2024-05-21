using _1_API.Response;
using _3_Data.Models;
using AutoMapper;

namespace _1_API.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse()
    {
        CreateMap<Product, ProductResponse>();
    }
}