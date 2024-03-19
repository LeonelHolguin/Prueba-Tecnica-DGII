using ContributorManager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContributorManager.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<TaxReceipt> TaxReceipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Contributor>().ToTable("Contributors");
            modelBuilder.Entity<TaxReceipt>().ToTable("TaxReceipts");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Contributor>().HasKey(contributor => contributor.TaxIdentificationNumber);
            modelBuilder.Entity<TaxReceipt>().HasKey(taxReceipt => taxReceipt.TaxVerificationNumber);
            #endregion

            #region relationships
            modelBuilder.Entity<Contributor>()
                .HasMany<TaxReceipt>(contributor => contributor.TaxReceipts)
                .WithOne(taxReceipt => taxReceipt.Contributor)
                .HasForeignKey(taxReceipt => taxReceipt.TaxIdentificationNumber)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configurations"

            #region Contributor
            modelBuilder.Entity<Contributor>().Property(p => p.Name)
                .IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Contributor>().Property(p => p.Type)
                .IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Contributor>().Property(p => p.Status)
                .IsRequired().HasMaxLength(20);
            #endregion

            #region TaxReceipt
            modelBuilder.Entity<TaxReceipt>().Property(p => p.Amount)
                .IsRequired();

            modelBuilder.Entity<TaxReceipt>().Property(p => p.VAT18)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
