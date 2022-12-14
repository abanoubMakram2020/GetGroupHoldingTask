// <auto-generated />
using System;
using GetGroupHoldingTask.Infrastructure.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GetGroupHoldingTask.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Customer", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Assuit",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6468),
                            DateOfBirth = new DateTime(1991, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Abanoub@gmail.com",
                            Job = "Software Engineer",
                            Name = "Abanoub Makram",
                            Phone = "01273925676"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Cairo",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6482),
                            DateOfBirth = new DateTime(1990, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Ahmed@gmail.com",
                            Job = "Tester Engineer",
                            Name = "Ahmed Ali",
                            Phone = "01073925676"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Alex",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6484),
                            DateOfBirth = new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Mariam@gmail.com",
                            Job = "Business Analyist",
                            Name = "Mariam Lotfy",
                            Phone = "01173925655"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Giz",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6487),
                            DateOfBirth = new DateTime(1980, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Mohammed@gmail.com",
                            Job = "Service delivery",
                            Name = "Mohammed Hussien",
                            Phone = "0100005676"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Giza",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6489),
                            DateOfBirth = new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Akram@gmail.com",
                            Job = "Footballer",
                            Name = "Akram twfiq",
                            Phone = "01073929543"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Cairo",
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6491),
                            DateOfBirth = new DateTime(1995, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Said@gmail.com",
                            Job = "Footballer",
                            Name = "Said Zezo",
                            Phone = "01598524676"
                        });
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CustomerId = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6570),
                            TotalAmount = 5000m
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CustomerId = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6573),
                            TotalAmount = 10000m
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CustomerId = 2,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6575),
                            TotalAmount = 8000m
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CustomerId = 2,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6576),
                            TotalAmount = 3000m
                        });
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 3000m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6588),
                            Item = "Item1",
                            ItemPrice = 500m,
                            NumberOfItems = 6,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2000m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6592),
                            Item = "Item2",
                            ItemPrice = 200m,
                            NumberOfItems = 10,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1800m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6594),
                            Item = "Item3",
                            ItemPrice = 300m,
                            NumberOfItems = 6,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 4,
                            Amount = 4200m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6595),
                            Item = "Item4",
                            ItemPrice = 200m,
                            NumberOfItems = 21,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 5,
                            Amount = 4000m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6597),
                            Item = "Item5",
                            ItemPrice = 500m,
                            NumberOfItems = 8,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 6,
                            Amount = 8000m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6598),
                            Item = "Item6",
                            ItemPrice = 800m,
                            NumberOfItems = 10,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 7,
                            Amount = 1500m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6600),
                            Item = "Item7",
                            ItemPrice = 250m,
                            NumberOfItems = 6,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 8,
                            Amount = 1500m,
                            CreatedBy = 1,
                            DateCreated = new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6601),
                            Item = "Item8",
                            ItemPrice = 150m,
                            NumberOfItems = 10,
                            OrderId = 4
                        });
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.Order", b =>
                {
                    b.HasOne("GetGroupHoldingTask.Domain.Data.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("GetGroupHoldingTask.Domain.Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GetGroupHoldingTask.Domain.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
