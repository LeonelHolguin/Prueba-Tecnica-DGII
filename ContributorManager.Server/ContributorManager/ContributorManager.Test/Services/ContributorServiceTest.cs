using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Application.Services;
using ContributorManager.Core.Application.ViewModels.Contributors;
using ContributorManager.Core.Domain.Entities;
using FluentAssertions;
using Moq;

namespace ContributorManager.Test.Services
{
    public class ContributorServiceTest
    {
        private readonly Mock<IContributorRepository> _contributorRepository;
        public ContributorServiceTest()
        {
            _contributorRepository = new Mock<IContributorRepository>();
        }

        [Fact]
        public async Task ContributorService_GetAllContributors_ReturnContributorList()
        {
            // Arrange
            var contributorList = new List<Contributor>
            {
                new Contributor { TaxIdentificationNumber = Guid.NewGuid().ToString(), Name = "Juan Pérez", Type = "PERSONA FISICA", Status = "ACTIVO" },
                new Contributor { TaxIdentificationNumber = Guid.NewGuid().ToString(), Name = "La Casa del Pan", Type = "PERSONA JURIDICA", Status = "INACTIVO" },
            };
            _contributorRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(contributorList);
            var service = new ContributorService(_contributorRepository.Object);

            // Act
            var result = await service.GetAllContributors();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<ContributorViewModel>>();
        }
    }
}
