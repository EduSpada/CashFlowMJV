using CashFlowMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowMvc.Infra.Data.EntitiesConfiguration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();

            builder.HasData(
                new PaymentMethod(1, "inflow exemple", 1),
                new PaymentMethod(2, "outflow exemple", 2)
            );
        }
    }
}