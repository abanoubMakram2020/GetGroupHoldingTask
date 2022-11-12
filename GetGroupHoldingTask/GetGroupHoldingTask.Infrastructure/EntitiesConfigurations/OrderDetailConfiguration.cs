using GetGroupHoldingTask.Domain.Data.Entities;
using GetGroupHoldingTask.Infrastructure.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetGroupHoldingTask.Infrastructure.EntitiesConfigurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(name: TableName.OrderDetail, schema: Schema.dbo);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.OrderId).HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.Item).HasColumnType(ColumnType.Nvarchar64).IsRequired();
            builder.Property(p => p.ItemPrice).HasColumnType(ColumnType.Decimal18_2).IsRequired();
            builder.Property(p => p.NumberOfItems).HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.Amount).HasColumnType(ColumnType.Decimal18_2).IsRequired();

            builder.Property(p => p.DateCreated);

            builder.HasOne(o => o.Order).WithMany(m => m.OrderDetails).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
