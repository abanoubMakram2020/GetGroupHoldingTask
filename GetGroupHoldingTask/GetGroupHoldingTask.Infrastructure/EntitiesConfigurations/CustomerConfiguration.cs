using GetGroupHoldingTask.Domain.Data.Entities;
using GetGroupHoldingTask.Infrastructure.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetGroupHoldingTask.Infrastructure.EntitiesConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(name: TableName.Customer, schema: Schema.dbo);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.Name).HasColumnType(ColumnType.Nvarchar256).IsRequired();
            builder.Property(p => p.DateOfBirth);
            builder.Property(p => p.Job).HasColumnType(ColumnType.Nvarchar64).IsRequired();
            builder.Property(p => p.Address).HasColumnType(ColumnType.Nvarchar64).IsRequired();
            builder.Property(p => p.Phone).HasColumnType(ColumnType.Nvarchar16).IsRequired();
            builder.Property(p => p.Email).HasColumnType(ColumnType.Nvarchar64).IsRequired();
            builder.Property(p => p.DateCreated);

          
        }
    }
}
