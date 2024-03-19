
namespace ContributorManager.Core.Application.ViewModels.Contributors
{
    public class ContributorViewModel
    {
        public required string TaxIdentificationNumber { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
    }
}
