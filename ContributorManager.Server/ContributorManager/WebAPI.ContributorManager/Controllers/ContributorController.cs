using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.Contributors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.ContributorManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorController : ControllerBase
    {
        private readonly IContributorService _contributorService;

        public ContributorController(IContributorService contributorService)
        {
            _contributorService = contributorService;
        }

        [HttpGet]
        [Route("GetContributors")]
        public async Task<IActionResult> GetAllContributors()
        {
            List<ContributorViewModel> contributorList = new();

            try
            {
                contributorList = await _contributorService.GetAllContributors();

            } catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadGateway);
            }

            return Ok(contributorList);
        }
    }
}
