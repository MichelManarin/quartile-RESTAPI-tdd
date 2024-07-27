using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Stores.API.Controllers;
using Stores.API.Models;
using Stores.UnitTests.Helpers;

namespace Stores.UnitTests.Systems.Controllers;

public class TestStoreController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();
        var mockLogger = new Mock<ILogger<StoreController>>();

        mockStoreService
            .Setup(service => service.GetAllStoresAsync())
            .ReturnsAsync(new List<Store>());

        mockCompanyService
            .Setup(service => service.GetByIdAsync(1))
            .ReturnsAsync(new Company());

        var sut = new StoreControllerFixture(mockStoreService, mockCompanyService).CreateController();

        var result = (OkObjectResult)await sut.Get(TestDataGenerator.GetFakeCompanyId());

        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesStoreService()
    {
        var mockStoreService = new Mock<IStoreService>();

        mockStoreService
            .Setup(service => service.GetAllStoresAsync())
            .ReturnsAsync(new List<Store>());

        var sut = new StoreControllerFixture(mockStoreService).CreateController();

        var result = await sut.Get(TestDataGenerator.GetFakeCompanyId());

        mockStoreService.Verify(service =>
           service.GetAllStoresAsync(),
           Times.Once()
        );
    }

    [Fact]
    public async Task Post_OnSuccess_InvokesCompanyService()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();

        mockCompanyService
          .Setup(service => service.GetByIdAsync(TestDataGenerator.GetFakeCompanyId()))
          .ReturnsAsync(new Company());

        var sut = new StoreControllerFixture(null, mockCompanyService).CreateController();

        var result = await sut.Add(TestDataGenerator.GetFakeCompanyId(), TestDataGenerator.CreateFakeStoreViewModel());

        mockCompanyService.Verify(service =>
            service.GetByIdAsync(TestDataGenerator.GetFakeCompanyId()),
            Times.Once()
        );
    }

    [Fact]
    public async Task Post_OnBadRequest_InvalidCompany()
    {
        var mockCompanyService = new Mock<ICompanyService>();
        var fakeStoreModel = TestDataGenerator.CreateFakeStoreModel();
        var fakeStoreViewModel = TestDataGenerator.CreateFakeStoreViewModel();

        mockCompanyService
            .Setup(service => service.GetByIdAsync(1))
            .ReturnsAsync((Company?)null);


        var sut = new StoreControllerFixture(null, mockCompanyService).CreateController();

        var result = await sut.Add(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badRequestResult.StatusCode);
    }

    [Fact]
    public async Task Post_OnSuccess_ValidCompany()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();

        var fakeStoreModel = TestDataGenerator.CreateFakeStoreModel();
        var fakeStoreViewModel = TestDataGenerator.CreateFakeStoreViewModel();

        mockCompanyService
            .Setup(service => service.GetByIdAsync(TestDataGenerator.GetFakeCompanyId()))
            .ReturnsAsync(TestDataGenerator.CreateFakeCompanyModel());

        mockStoreService
                .Setup(service => service.AddStoreAsync(TestDataGenerator.CreateFakeStoreModel()));

        var sut = new StoreControllerFixture(mockStoreService, mockCompanyService).CreateController();

        var result = await sut.Add(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel);

        var badRequestResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, badRequestResult.StatusCode);
    }

    [Fact]
    public async Task Delete_OnSuccess_Store()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();

        var fakeStoreModel = TestDataGenerator.CreateFakeStoreModel();
        var fakeStoreViewModel = TestDataGenerator.CreateFakeStoreViewModel();

        mockCompanyService
            .Setup(service => service.GetByIdAsync(TestDataGenerator.GetFakeCompanyId()))
            .ReturnsAsync(TestDataGenerator.CreateFakeCompanyModel());

        mockStoreService
            .Setup(service => service.GetStoreByIdAndCompanyAsync(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel.Id))
            .ReturnsAsync(TestDataGenerator.CreateFakeStoreModel());

        mockStoreService
            .Setup(service => service.RemoveStoreAsync(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel.Id));

        var sut = new StoreControllerFixture(mockStoreService, mockCompanyService).CreateController();

        var result = await sut.Remove(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel.Id);

        var badRequestResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, badRequestResult.StatusCode);
    }

    [Fact]
    public async Task Delete_OnFail_Store()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();

        var fakeStoreModel = TestDataGenerator.CreateFakeStoreModel();
        var fakeStoreViewModel = TestDataGenerator.CreateFakeStoreViewModel();

        mockCompanyService
            .Setup(service => service.GetByIdAsync(TestDataGenerator.GetFakeCompanyId()))
            .ReturnsAsync(TestDataGenerator.CreateFakeCompanyModel());

        mockStoreService
            .Setup(service => service.GetStoreByIdAndCompanyAsync(7, 1))
            .ReturnsAsync((Store)null);

        var sut = new StoreControllerFixture(mockStoreService, mockCompanyService).CreateController();

        var result = await sut.Remove(TestDataGenerator.GetFakeCompanyId(), fakeStoreViewModel.Id);

        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task Patch_OnSuccess_InvokesStoreService()
    {
        var mockStoreService = new Mock<IStoreService>();
        var mockCompanyService = new Mock<ICompanyService>();

        mockStoreService
          .Setup(service => service.GetStoreByIdAndCompanyAsync(TestDataGenerator.GetFakeCompanyId(), TestDataGenerator.CreateFakeStoreModel().Id))
          .ReturnsAsync(TestDataGenerator.CreateFakeStoreModel());   

        mockStoreService
          .Setup(service => service.UpdateStoreAsync(TestDataGenerator.GetFakeCompanyId(), TestDataGenerator.CreateFakeStoreModel()));

        var sut = new StoreControllerFixture(mockStoreService, mockCompanyService).CreateController();

        var result = await sut.Update(TestDataGenerator.GetFakeCompanyId(), TestDataGenerator.CreateFakeStoreViewModel());

        result.Should().NotBeNull();
    }
}
