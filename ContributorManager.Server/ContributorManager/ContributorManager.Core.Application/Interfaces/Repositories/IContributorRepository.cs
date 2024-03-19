using ContributorManager.Core.Domain.Entities;

namespace ContributorManager.Core.Application.Interfaces.Repositories
{
    public interface IContributorRepository
    {
        Task<List<Contributor>> GetAllAsync();
    }
}
