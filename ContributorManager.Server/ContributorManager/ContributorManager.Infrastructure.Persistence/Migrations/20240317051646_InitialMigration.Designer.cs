﻿// <auto-generated />
using ContributorManager.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContributorManager.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240317051646_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("ContributorManager.Core.Domain.Entities.Contributor", b =>
                {
                    b.Property<string>("TaxIdentificationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("TaxIdentificationNumber");

                    b.ToTable("Contributors", (string)null);
                });

            modelBuilder.Entity("ContributorManager.Core.Domain.Entities.TaxReceipt", b =>
                {
                    b.Property<string>("TaxVerificationNumber")
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("TaxIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("VAT18")
                        .HasColumnType("REAL");

                    b.HasKey("TaxVerificationNumber");

                    b.HasIndex("TaxIdentificationNumber");

                    b.ToTable("TaxReceipts", (string)null);
                });

            modelBuilder.Entity("ContributorManager.Core.Domain.Entities.TaxReceipt", b =>
                {
                    b.HasOne("ContributorManager.Core.Domain.Entities.Contributor", "Contributor")
                        .WithMany("TaxReceipts")
                        .HasForeignKey("TaxIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("ContributorManager.Core.Domain.Entities.Contributor", b =>
                {
                    b.Navigation("TaxReceipts");
                });
#pragma warning restore 612, 618
        }
    }
}
