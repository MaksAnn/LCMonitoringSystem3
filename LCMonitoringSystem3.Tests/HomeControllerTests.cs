using Microsoft.AspNetCore.Mvc;
using LCMonitoringSystem3.Controllers;
using Xunit;

namespace LCMonitoringSystem3.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}
