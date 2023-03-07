using CashFlowMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowMvc.Infra.Data.EntitiesConfiguration
{
    public class OperationsConfigurations : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();

            builder.Property(p => p.Value).HasPrecision(10, 2);

            builder.HasOne(e => e.PaymentMethod).WithMany(p => p.Operations).HasForeignKey(e => e.PaymentMethodId);

            builder.HasData(
                new Operation(1, "George Wells Company", 3015.17m, 1),
                new Operation(2, "Maden Market", 183.25m, 2),
                new Operation(3, "Cleaner Services S/A", 15850.13m, 2),
                new Operation(4, "Paul Walker Acessories", 11012.33m, 1),
                new Operation(5, "Midnight Events", 5489.85m, 1),
                new Operation(6, "Energy Company", 2123.74m, 2)
            );
        }
    }
}