using ContributorManager.Core.Domain.Entities;
using ContributorManager.Infrastructure.Persistence.Contexts;
using ContributorManager.Infrastructure.Persistence.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ContributorManager.Test.Repositories
{
    public class TaxReceiptRepositoryTest
    {
        Random rand = new Random();

        private async Task<ApplicationContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var applicationContext = new ApplicationContext(options);
            applicationContext.Database.EnsureCreated();
            if (await applicationContext.TaxReceipts.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    var amountRandom = rand.Next(1001);

                    applicationContext.TaxReceipts.Add(
                        new TaxReceipt()
                        {
                            TaxVerificationNumber = $"E{3100000000 + (i + 1)}", 
                            Amount = amountRandom,
                            VAT18 = double.Parse((amountRandom * 0.18).ToString("0.00")),
                            TaxIdentificationNumber = Guid.NewGuid().ToString()
                        }
                    );
                }
                await applicationContext.SaveChangesAsync();
            }
            return applicationContext;
        }

        [Fact]
        public async Task TaxReceiptRepository_GetAllAsync_ReturnTaxReceiptList()
        {
            // Arrange
            var dbContext = await GetApplicationContext();
            var taxReceiptRepository = new TaxReceiptRepository(dbContext);

            // Act
            var result = await taxReceiptRepository.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<TaxReceipt>>();
        }
    }
}
