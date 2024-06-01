using _1_API.Controllers;
using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Maki.Presentation.Test;

public class CategoryControllerUnitTest
{
    [Fact]
    public async Task GetAsync_ResultOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();

        var fakeList = new List<Category>();
        fakeList.Add(new Category());
        mockCategoryData.Setup(p=>p.GetAllAsync()).ReturnsAsync(fakeList);
        
        var fakeResultList = new List<CategoryResponse>();
        fakeResultList.Add(new CategoryResponse());
        
        mockMapper.Setup(m=>m.Map<List<Category>, List<CategoryResponse>>(It.IsAny<List<Category>>())).Returns(fakeResultList);
        
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
        
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
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();

        var fakeList = new List<Category>();
        mockCategoryData.Setup(p=>p.GetAllAsync()).ReturnsAsync(fakeList);
        
        var fakeResultList = new List<CategoryResponse>();
        mockMapper.Setup(m=>m.Map<List<Category>, List<CategoryResponse>>(It.IsAny<List<Category>>())).Returns(fakeResultList);
        
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
        
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
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();
    
        var fakeCategoryRequest = new CategoryRequest();
    
        mockMapper.Setup(m=>m.Map<CategoryRequest, Category>(It.IsAny<CategoryRequest>())).Returns(new Category());
        mockCategoryDomain.Setup(p=>p.SaveAsync(It.IsAny<Category>())).Returns(Task.FromResult(1));
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PostAsync(fakeCategoryRequest);

        //Assert
        Assert.IsType<StatusCodeResult>(result);
    }
    
    [Fact]
    public async Task PostAsync_ReturnsBadRequest()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();
    
        var fakeCategoryRequest = new CategoryRequest();
    
        mockMapper.Setup(m=>m.Map<CategoryRequest, Category>(It.IsAny<CategoryRequest>())).Returns(new Category());
        mockCategoryDomain.Setup(p=>p.SaveAsync(It.IsAny<Category>())).Returns(Task.FromResult(0));
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PostAsync(fakeCategoryRequest);

        //Assert
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task PutAsync_ReturnsOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();
    
        var fakeCategoryRequest = new CategoryRequest();
    
        mockMapper.Setup(m=>m.Map<CategoryRequest, Category>(It.IsAny<CategoryRequest>())).Returns(new Category());
        mockCategoryDomain.Setup(p=>p.UpdateAsync(It.IsAny<Category>(), 1 ) ).Returns(Task.FromResult(true));
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
    
        //Act
        var result = await controller.PutAsync(1,fakeCategoryRequest);

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async Task DeleteAsync_ResultOk()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockCategoryData = new Mock<ICategoryData>();
        var mockCategoryDomain = new Mock<ICategoryDomain>();

        var fakeCategory = new Category();
        mockCategoryData.Setup(p=>p.GetById(It.IsAny<int>())).Returns(fakeCategory);
        mockCategoryData.Setup(p => p.DeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
        
        var controller = new CategoryController(mockCategoryData.Object, mockCategoryDomain.Object, mockMapper.Object);
        
        //Act
        var result = await controller.DeleteAsync(1);

        //Assert
        Assert.IsType<OkResult>(result);
    }
}