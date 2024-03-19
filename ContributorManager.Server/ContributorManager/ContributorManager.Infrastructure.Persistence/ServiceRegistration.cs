using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Infrastructure.Persistence.Contexts;
using ContributorManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContributorManager.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite(connectionString,
                    m =>
                    {
                        m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName);
                    });
            });
            #endregion

            #region Repositories
            services.AddTransient<IContributorRepository, ContributorRepository>();
            services.AddTransient<ITaxReceiptRepository, TaxReceiptRepository>();
            #endregion
        }
    }
}
