using _3_Data;
using _3_Data.Models;
using Moq;
using NSubstitute;

namespace _2_Domain.Test;

public class CategoryDomainUnitTest
{
    [Fact]
    public async Task SaveAsync_ValidInput_ReturnValidId()
    {
        //Arrange
        var input = new Category()
        {
            Name = "Name"
        };

        var mock = new Mock<ICategoryData>();

        mock.Setup(data => data.GetByNameAsync(input.Name)).ReturnsAsync((Category)null);
        mock.Setup(data => data.SaveAsync(input)).ReturnsAsync(1);

        CategoryDomain categoryDomain = new CategoryDomain(mock.Object);

        //Act
        var result = await categoryDomain.SaveAsync(input);

        //Assert
        Assert.Equal(1, result);
    }
    
    [Fact]
    public async Task SaveAsync_ExistingName_ThrowsException()
    {
        //Arrange
        var input = new Category()
        {
            Name = "Name"
        };
        
        var mock = new Mock<ICategoryData>();
        
        mock.Setup(data => data.GetByNameAsync(input.Name)).ReturnsAsync(input);
        mock.Setup(data => data.SaveAsync(input)).ThrowsAsync(new Exception("Name already exists."));

        CategoryDomain categoryDomain = new CategoryDomain(mock.Object);

        //Act and Assert
        Assert.ThrowsAsync<Exception>(async ()=> await categoryDomain.SaveAsync(input));
    }
    
    [Fact]
    public async Task UpdateAsync_ExistingId_ReturnsTrue()
    {
        //Arrange
        var id = 10;
        var input = new Category()
        {
            Name = "Name"
        };
        
        var categoryDataMock = Substitute.For<ICategoryData>();
        
        categoryDataMock.GetById(id).Returns(new Category());
        categoryDataMock.UpdateAsync(input, id).Returns(true);
        
        CategoryDomain categoryDomain = new CategoryDomain(categoryDataMock);

        //Act
        var result=  await categoryDomain.UpdateAsync(input, id);

        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public async Task DeleteAsync_ExistingId_ReturnsTrue()
    {
        //Arrange
        var id = 10;
        var categoryDataMock = Substitute.For<ICategoryData>();
        
        categoryDataMock.GetById(id).Returns(new Category());
        categoryDataMock.DeleteAsync(id).Returns(true);
        
        CategoryDomain categoryDomain = new CategoryDomain(categoryDataMock);

        //Act
        var result=  await categoryDomain.DeleteAsync(id);

        //Assert
        Assert.True(result);
    }
}