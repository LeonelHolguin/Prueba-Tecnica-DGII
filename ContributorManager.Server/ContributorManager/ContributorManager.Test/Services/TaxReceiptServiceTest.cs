using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Application.Services;
using ContributorManager.Core.Application.ViewModels.TaxReceipts;
using ContributorManager.Core.Domain.Entities;
using FluentAssertions;
using Moq;

namespace ContributorManager.Test.Services
{
    public class TaxReceiptServiceTest
    {
        private readonly Mock<ITaxReceiptRepository> _taxReceiptRepository;
        public TaxReceiptServiceTest()
        {
            _taxReceiptRepository = new Mock<ITaxReceiptRepository>();
        }

        [Fact]
        public async Task TaxReceiptService_GetAllTaxReceipts_ReturnTaxReceiptList()
        {
            // Arrange
            var taxReceiptList = new List<TaxReceipt>
            {
                new TaxReceipt { TaxVerificationNumber = "E31000000001", Amount = 500.00, VAT18 = 90.00, TaxIdentificationNumber = "892381471485" },
                new TaxReceipt { TaxVerificationNumber = "E31000000002", Amount = 1000.00, VAT18 = 180.00, TaxIdentificationNumber = "892381471485" },
            };
            _taxReceiptRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(taxReceiptList);
            var service = new TaxReceiptService(_taxReceiptRepository.Object);

            // Act
            var result = await service.GetAllTaxReceipts();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<TaxReceiptViewModel>>();
        }
    }
}
