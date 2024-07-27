using Stores.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using Stores.API.Models;
using Stores.UnitTests.Helpers;

namespace Stores.UnitTests.Systems.Controllers;

public class TestCompanyController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mockCompanyService = new Mock<ICompanyService>();

        mockCompanyService
            .Setup(service => service.GetAllCompaniesAsync())
            .ReturnsAsync(new List<Company>());

        var sut = new CompanyControllerFixture(mockCompanyService).CreateController();

        var result = (OkObjectResult)await sut.Get();

        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokesCompanyService()
    {
        var mockCompanyService = new Mock<ICompanyService>();

        mockCompanyService
            .Setup(service => service.GetAllCompaniesAsync())
            .ReturnsAsync(new List<Company>());

        var sut = new CompanyControllerFixture(mockCompanyService).CreateController();

        var result = await sut.Get();

        mockCompanyService.Verify(service => 
            service.GetAllCompaniesAsync(),
            Times.Once()
        );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfCompanys()
    {
        var mockCompanyService = new Mock<ICompanyService>();

        mockCompanyService
            .Setup(service => service.GetAllCompaniesAsync())
            .ReturnsAsync(new List<Company>());

        var sut = new CompanyControllerFixture(mockCompanyService).CreateController();

        var result = await sut.Get();

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Company>>();
    }

    [Fact]
    public void Post_OnSuccess_ReturnsOkObject()
    {
        var mockCompanyService = new Mock<ICompanyService>();

        var fakeAddress = TestDataGenerator.CreateFakeAddressModel();
        var fakeCompanyView = TestDataGenerator.CreateFakeCompanyViewModel();

        var sut = new CompanyControllerFixture(mockCompanyService).CreateController();

        var result = sut.Add(fakeCompanyView);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Post_OnSuccess_InvokesCompanyService()
    {
        var mockCompanyService = new Mock<ICompanyService>();

        mockCompanyService
            .Setup(service => service.GetAllCompaniesAsync())
            .ReturnsAsync(new List<Company>());

        var sut = new CompanyControllerFixture(mockCompanyService).CreateController();
        var fakeAddress = TestDataGenerator.CreateFakeAddressModel();
        var fakeCompanyView = TestDataGenerator.CreateFakeCompanyViewModel();

        var result = sut.Add(fakeCompanyView);

        mockCompanyService.Verify(service =>
             service.AddCompanyAsync(It.Is<Company>(c =>
                 c.Name == fakeCompanyView.Name &&
                 c.Address.Street == fakeCompanyView.Address.Street &&
                 c.Address.City == fakeCompanyView.Address.City &&
                 c.Address.State == fakeCompanyView.Address.State &&
                 c.Address.Country == fakeCompanyView.Address.Country &&
                 c.Address.ZipCode == fakeCompanyView.Address.ZipCode)), Times.Once);
    }
}