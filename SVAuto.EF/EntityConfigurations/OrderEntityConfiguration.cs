using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SVAuto.EF.Model;

namespace SVAuto.EF.EntityConfigurations
{
    public class OrderEntityConfiguration
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Phone)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(o => o.Part)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(o => o.CreationDateTime)
                .IsRequired();
            builder.Property(o => o.ModificationDateTime)
                .IsRequired();
            builder.Property(o => o.StatusId)
                .IsRequired();
        }
    }
}
