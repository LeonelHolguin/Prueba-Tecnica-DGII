using ContributorManager.Core.Application.Interfaces.Repositories;
using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.Contributors;

namespace ContributorManager.Core.Application.Services
{
    public class ContributorService : IContributorService
    {
        private readonly IContributorRepository _contributorRepository;
        public ContributorService(IContributorRepository contributorRepository) 
        { 
            _contributorRepository = contributorRepository;
        }

        public async Task<List<ContributorViewModel>> GetAllContributors()
        {
            var contributorList = await _contributorRepository.GetAllAsync();

            return contributorList.Select(contributor => new ContributorViewModel
            {
                TaxIdentificationNumber = contributor.TaxIdentificationNumber,
                Name = contributor.Name,
                Type = contributor.Type,
                Status = contributor.Status

            }).ToList();
        }
    }
}
