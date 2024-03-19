using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContributorManager.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IContributorService, ContributorService>();
            services.AddTransient<ITaxReceiptService, TaxReceiptService>();
            #endregion
        }
    }
}
