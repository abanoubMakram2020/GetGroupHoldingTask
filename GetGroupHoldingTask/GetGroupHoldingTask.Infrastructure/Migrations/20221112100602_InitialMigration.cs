using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGroupHoldingTask.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Customer",
                columns: new[] { "Id", "Address", "CreatedBy", "DateCreated", "DateOfBirth", "Email", "Job", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Assuit", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6468), new DateTime(1991, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abanoub@gmail.com", "Software Engineer", "Abanoub Makram", "01273925676" },
                    { 2, "Cairo", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6482), new DateTime(1990, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed@gmail.com", "Tester Engineer", "Ahmed Ali", "01073925676" },
                    { 3, "Alex", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6484), new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariam@gmail.com", "Business Analyist", "Mariam Lotfy", "01173925655" },
                    { 4, "Giz", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6487), new DateTime(1980, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohammed@gmail.com", "Service delivery", "Mohammed Hussien", "0100005676" },
                    { 5, "Giza", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6489), new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akram@gmail.com", "Footballer", "Akram twfiq", "01073929543" },
                    { 6, "Cairo", 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6491), new DateTime(1995, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Said@gmail.com", "Footballer", "Said Zezo", "01598524676" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Order",
                columns: new[] { "Id", "CreatedBy", "CustomerId", "DateCreated", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6570), 5000m },
                    { 2, 1, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6573), 10000m },
                    { 3, 1, 2, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6575), 8000m },
                    { 4, 1, 2, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6576), 3000m }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderDetail",
                columns: new[] { "Id", "Amount", "CreatedBy", "DateCreated", "Item", "ItemPrice", "NumberOfItems", "OrderId" },
                values: new object[,]
                {
                    { 1, 3000m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6588), "Item1", 500m, 6, 1 },
                    { 2, 2000m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6592), "Item2", 200m, 10, 1 },
                    { 3, 1800m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6594), "Item3", 300m, 6, 2 },
                    { 4, 4200m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6595), "Item4", 200m, 21, 2 },
                    { 5, 4000m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6597), "Item5", 500m, 8, 2 },
                    { 6, 8000m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6598), "Item6", 800m, 10, 3 },
                    { 7, 1500m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6600), "Item7", 250m, 6, 4 },
                    { 8, 1500m, 1, new DateTime(2022, 11, 12, 12, 6, 2, 635, DateTimeKind.Local).AddTicks(6601), "Item8", 150m, 10, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "dbo",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "dbo",
                table: "OrderDetail",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");
        }
    }
}
