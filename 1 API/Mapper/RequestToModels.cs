﻿using _1_API.Request;
using _3_Data.Models;
using AutoMapper;

namespace _1_API.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<CategoryRequest, Category>();
        CreateMap<CustomerRequest, Customer>();

    }
    
}