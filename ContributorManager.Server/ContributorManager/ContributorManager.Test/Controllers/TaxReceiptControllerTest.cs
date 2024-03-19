using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.TaxReceipts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.ContributorManager.Controllers;

namespace ContributorManager.Test.Controllers
{
    public class TaxReceiptControllerTest
    {
        private readonly Mock<ITaxReceiptService> _taxReceiptService;

        public TaxReceiptControllerTest()
        {
            _taxReceiptService = new Mock<ITaxReceiptService>();
        }

        [Fact]
        public async Task TaxReceiptController_GetAllTaxReceipts_ReturnOk()
        {
            // Arrange
            var taxReceiptList = new List<TaxReceiptViewModel>();
            _taxReceiptService.Setup(service => service.GetAllTaxReceipts()).ReturnsAsync(taxReceiptList);
            var controller = new TaxReceiptController(_taxReceiptService.Object);

            // Act
            var result = await controller.GetAllTaxReceipts();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
