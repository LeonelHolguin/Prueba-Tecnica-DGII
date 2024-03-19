using ContributorManager.Core.Domain.Entities;
using ContributorManager.Infrastructure.Persistence.Contexts;
using ContributorManager.Infrastructure.Persistence.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ContributorManager.Test.Repositories
{
    public class ContributorRepositoryTest
    {
        private string[] nameList = new string[10]
        {
            "Juan Pérez",
            "La Casa del Pan",
            "María Rodríguez",
            "El Jardín de las Flores",
            "Carlos Gómez",
            "Supermercado La Canasta",
            "Ana Martínez",
            "Restaurante El Buen Sabor",
            "Pedro Castillo",
            "Librería La Cultura"
        };

        private string[] typeList = new string[2]
        {
            "PERSONA FISICA",
            "PERSONA JURIDICA"
        };

        private string[] statusList = new string[2]
        {
            "ACTIVO",
            "INACTIVO"
        };

        Random rand = new Random();

        private async Task<ApplicationContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var applicationContext = new ApplicationContext(options);
            applicationContext.Database.EnsureCreated();
            if (await applicationContext.Contributors.CountAsync() <= 0 ) 
            { 
                for (int i = 0; i < 10;  i++) 
                {
                    applicationContext.Contributors.Add(
                        new Contributor()
                        {
                            TaxIdentificationNumber = Guid.NewGuid().ToString(),
                            Name = nameList[i],
                            Type = typeList[rand.Next(2)],
                            Status = statusList[rand.Next(2)]
                        }
                    );                
                }
                await applicationContext.SaveChangesAsync();
            }
            return applicationContext;
        }

        [Fact]
        public async Task ContributorRepository_GetAllAsync_ReturnContributorList()
        {
            // Arrange
            var dbContext = await GetApplicationContext();
            var contributorRepository = new ContributorRepository(dbContext);

            // Act
            var result = await contributorRepository.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Contributor>>();
        }
    }
}
