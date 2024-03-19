using ContributorManager.Core.Application.ViewModels.Contributors;

namespace ContributorManager.Core.Application.Interfaces.Services
{
    public interface IContributorService
    {
        Task<List<ContributorViewModel>> GetAllContributors();
    }
}
