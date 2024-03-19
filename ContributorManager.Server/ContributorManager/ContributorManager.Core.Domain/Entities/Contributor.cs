
namespace ContributorManager.Core.Domain.Entities
{
    public class Contributor
    {
        public required string TaxIdentificationNumber { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }

        #region "Navigation property"
        public ICollection<TaxReceipt>? TaxReceipts { get; set; }
        #endregion
    }
}
