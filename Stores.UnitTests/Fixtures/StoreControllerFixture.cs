using Microsoft.Extensions.Logging;
using Moq;
using Stores.API.Controllers;

public class StoreControllerFixture
{
    public Mock<IStoreService> MockStoreService { get; private set; }
    public Mock<ICompanyService> MockCompanyService { get; private set; }
    public Mock<ILogger<StoreController>> MockLogger { get; private set; }
    public StoreControllerFixture(
        Mock<IStoreService>? mockStoreService = null,
        Mock<ICompanyService>? mockCompanyService = null,
        Mock<ILogger<StoreController>>? mockLogger = null)
    {
        MockStoreService = mockStoreService ?? new Mock<IStoreService>();
        MockCompanyService = mockCompanyService ?? new Mock<ICompanyService>();
        MockLogger = mockLogger ?? new Mock<ILogger<StoreController>>();
    }

    public StoreController CreateController()
    {
        return new StoreController(MockStoreService.Object, MockCompanyService.Object, MockLogger.Object);
    }
}