using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.Contributors;
using WebAPI.ContributorManager.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContributorManager.Test.Controllers
{
    public class ContributorControllerTest
    {
        private readonly Mock<IContributorService> _contributorService;

        public ContributorControllerTest()
        {
            _contributorService = new Mock<IContributorService>();
        }

        [Fact]
        public async Task ContributorController_GetAllContributors_ReturnOk()
        {
            // Arrange
            var contributorList = new List<ContributorViewModel>();
            _contributorService.Setup(service => service.GetAllContributors()).ReturnsAsync(contributorList);
            var controller = new ContributorController(_contributorService.Object);

            // Act
            var result = await controller.GetAllContributors();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
