using System.Net;
using _1_API.Controllers;
using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Maki.Presentation.Test;

public class ProductControllerUnitTest
{
    [Fact]
    public async Task GetAsync_ResultOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();

        var fakeList = new List<Product>();
        fakeList.Add(new Product());
        mockProductData.Setup(p=>p.GetAllAsync()).ReturnsAsync(fakeList);
        
        var fakeResultList = new List<ProductResponse>();
        fakeResultList.Add(new ProductResponse());
        
        mockMapper.Setup(m=>m.Map<List<Product>, List<ProductResponse>>(It.IsAny<List<Product>>())).Returns(fakeResultList);
        
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
        
        //Act
        var result = controller.GetAsync();

        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetAsync_ResultNotFound()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();

        var fakeList = new List<Product>();
        mockProductData.Setup(p=>p.GetAllAsync()).ReturnsAsync(fakeList);
        
        var fakeResultList = new List<ProductResponse>();
        mockMapper.Setup(m=>m.Map<List<Product>, List<ProductResponse>>(It.IsAny<List<Product>>())).Returns(fakeResultList);
        
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
        
        //Act
        var result = controller.GetAsync();

        //Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PostAsync_Returns201()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();
    
        var fakeProductRequest = new ProductRequest();
    
        mockMapper.Setup(m=>m.Map<ProductRequest, Product>(It.IsAny<ProductRequest>())).Returns(new Product());
        mockProductDomain.Setup(p=>p.SaveAsync(It.IsAny<Product>())).Returns(Task.FromResult(1));
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PostAsync(fakeProductRequest);

        //Assert
        Assert.IsType<StatusCodeResult>(result);
    }
    
    [Fact]
    public async Task PostAsync_ReturnsBadRequest()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();
    
        var fakeProductRequest = new ProductRequest();
    
        mockMapper.Setup(m=>m.Map<ProductRequest, Product>(It.IsAny<ProductRequest>())).Returns(new Product());
        mockProductDomain.Setup(p=>p.SaveAsync(It.IsAny<Product>())).Returns(Task.FromResult(0));
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PostAsync(fakeProductRequest);

        //Assert
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task PutAsync_ReturnsOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();
    
        var fakeProductRequest = new ProductRequest();
    
        mockMapper.Setup(m=>m.Map<ProductRequest, Product>(It.IsAny<ProductRequest>())).Returns(new Product());
        mockProductDomain.Setup(p=>p.UpdateAsync(It.IsAny<Product>(), 1 ) ).Returns(Task.FromResult(true));
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PutAsync(1,fakeProductRequest);

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async Task DeleteAsync_ResultOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockProductData = new Mock<IProductData>();
        var mockProductDomain = new Mock<IProductDomain>();

        var fakeProduct = new Product();
        mockProductData.Setup(p=>p.GetById(It.IsAny<int>())).Returns(fakeProduct);
        mockProductData.Setup(p => p.DeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
        
        var controller = new ProductController(mockProductData.Object, mockProductDomain.Object, mockMapper.Object);
        
        //Act
        var result = await controller.DeleteAsync(1);

        //Assert
        Assert.IsType<OkResult>(result);
    }
}