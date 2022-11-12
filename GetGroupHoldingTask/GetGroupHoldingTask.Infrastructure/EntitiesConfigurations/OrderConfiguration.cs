using GetGroupHoldingTask.Domain.Data.Entities;
using GetGroupHoldingTask.Infrastructure.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetGroupHoldingTask.Infrastructure.EntitiesConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(name: TableName.Order, schema: Schema.dbo);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.CustomerId).HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.TotalAmount).HasColumnType(ColumnType.Decimal18_2).IsRequired();
            
            builder.Property(p => p.DateCreated);

            builder.HasOne(o => o.Customer).WithMany(m => m.Orders).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
