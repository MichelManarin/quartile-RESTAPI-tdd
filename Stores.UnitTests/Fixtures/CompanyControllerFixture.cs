using Microsoft.Extensions.Logging;
using Moq;
using Stores.API.Controllers;

public class CompanyControllerFixture
{
    public Mock<ICompanyService> MockCompanyService { get; private set; }
    public Mock<ILogger<CompanyController>> MockLogger { get; private set; }
    public CompanyControllerFixture(
        Mock<ICompanyService>? mockCompanyService = null,
        Mock<ILogger<CompanyController>>? mockLogger = null)
    {
        MockCompanyService = mockCompanyService ?? new Mock<ICompanyService>();
        MockLogger = mockLogger ?? new Mock<ILogger<CompanyController>>();
    }

    public CompanyController CreateController()
    {
        return new CompanyController(MockCompanyService.Object, MockLogger.Object);
    }
}