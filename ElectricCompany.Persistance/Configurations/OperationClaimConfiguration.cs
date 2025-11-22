using ElectricCompany.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricCompany.Persistance.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaims>
    {
        public void Configure(EntityTypeBuilder<OperationClaims> builder)
        {
            builder.HasKey(op => op.Id);
            builder.ToTable("OperationClaims");
        }
    }
}
