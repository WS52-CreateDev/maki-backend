using _3_Data;
using _3_Data.Models;
using AutoMapper.Configuration.Annotations;
using Moq;
using NSubstitute;

namespace _2_Domain.Test;

public class ProductDomainUnitTest
{
    [Fact]
    public async Task SaveAsync_ValidInput_ReturnValidId()
    {
        //Arrange
        var input = new Product()
        {
            Description = "Description",
            Name = "Name",
            CategoryId = 6
        };

        var mock = new Mock<IProductData>();

        mock.Setup(data => data.GetByNameAsync(input.Name)).ReturnsAsync((Product)null);
        mock.Setup(data => data.SaveAsync(input)).ReturnsAsync(1);

        ProductDomain productDomain = new ProductDomain(mock.Object);

        //Act
        var result = await productDomain.SaveAsync(input);

        //Assert
        Assert.Equal(1, result);

    }

    [Fact]
    public async Task SaveAsync_ExistingName_ThrowsException()
    {
        //Arrange
        var input = new Product()
        {
            Description = "Description",
            Name = "Name",
            CategoryId = 6
        };
        
        var mock = new Mock<IProductData>();
        
        mock.Setup(data => data.GetByNameAsync(input.Name)).ReturnsAsync(input);
        mock.Setup(data => data.SaveAsync(input)).ThrowsAsync(new Exception("Product already exists"));

        ProductDomain productDomain = new ProductDomain(mock.Object);

        //Act and Assert
        Assert.ThrowsAsync<Exception>(async ()=> await productDomain.SaveAsync(input));
    }
    
    [Fact]
    public async Task UpdateAsync_ExistingId_ReturnsTrue()
    {
        //Arrange
        var id = 10;
        var input = new Product()
        {
            Description = "Description",
            Name = "Name",
            CategoryId = 6
        };
        
        var productDataMock = Substitute.For<IProductData>();
        
        productDataMock.GetById(id).Returns(new Product());
        productDataMock.UpdateAsync(input, id).Returns(true);
        
        ProductDomain productDomain = new ProductDomain(productDataMock);

        //Act
        var result=  await productDomain.UpdateAsync(input, id);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_NotExistingId_ReturnsFalse()
    {
        //Arrange
        var id = 10;
        var input = new Product()
        {
            Description = "Description",
            Name = "Name",
            CategoryId = 6
        };
        var productDataMock = Substitute.For<IProductData>();
        
        productDataMock.GetById(id).Returns((Product)null);
        
        ProductDomain productDomain = new ProductDomain(productDataMock);

        //Act and Assert
        Assert.ThrowsAsync<Exception>(async ()=> await productDomain.UpdateAsync(input, id));
    }

    [Fact]
    public async Task DeleteAsync_ExistingId_ReturnsTrue()
    {
        //Arrange
        var id = 10;
        var productDataMock = Substitute.For<IProductData>();
        
        productDataMock.GetById(id).Returns(new Product());
        productDataMock.DeleteAsync(id).Returns(true);
        
        ProductDomain productDomain = new ProductDomain(productDataMock);

        //Act
        var result=  await productDomain.DeleteAsync(id);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_NotExistingId_ReturnsFalse()
    {
        //Arrange
        var id = 10;
        var productDataMock = Substitute.For<IProductData>();
        
        productDataMock.GetById(id).Returns((Product)null);
        
        ProductDomain productDomain = new ProductDomain(productDataMock);

        //Act and Assert
        Assert.ThrowsAsync<Exception>(async ()=> await productDomain.DeleteAsync(id));
    }
}