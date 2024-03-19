
namespace ContributorManager.Core.Domain.Entities
{
    public class TaxReceipt
    {
        public required string TaxVerificationNumber { get; set; }
        public double Amount { get; set; }
        public double VAT18 { get; set; }
        public required string TaxIdentificationNumber { get; set; }

        #region "Navigation property"
        public Contributor? Contributor { get; set; }
        #endregion

    }
}
