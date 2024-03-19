using ContributorManager.Core.Application.Interfaces.Services;
using ContributorManager.Core.Application.ViewModels.TaxReceipts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.ContributorManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxReceiptController : ControllerBase
    {
        private readonly ITaxReceiptService _taxReceiptService;

        public TaxReceiptController(ITaxReceiptService taxReceiptService)
        {
            _taxReceiptService = taxReceiptService;
        }

        [HttpGet]
        [Route("GetTaxReceipts")]
        public async Task<IActionResult> GetAllTaxReceipts()
        {
            List<TaxReceiptViewModel> taxReceiptList = new();

            try
            {
                taxReceiptList = await _taxReceiptService.GetAllTaxReceipts();

            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadGateway);
            }

            return Ok(taxReceiptList);
        }
    }
}
