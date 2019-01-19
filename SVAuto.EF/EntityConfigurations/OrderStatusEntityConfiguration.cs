using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SVAuto.EF.Model;

namespace SVAuto.EF.EntityConfigurations
{
    public class OrderStatusEntityConfiguration
        : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(s => s.Description)
                .HasMaxLength(100);
        }
    }
}
