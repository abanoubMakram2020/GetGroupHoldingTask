
using Microsoft.EntityFrameworkCore;
using GetGroupHoldingTask.Domain.Data.Entities;
using System.Xml.Linq;
using System.Net;
using System.Numerics;

namespace GetGroupHoldingTask.Infrastructure.SeedData
{
    public static class SeedingData
    {
        private static readonly DateTime _dataCreated = new DateTime(2022, 7, 5, 2, 44, 36);

        public static void StartSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.CustomerSeedData();
            modelBuilder.OrderSeedData();
            modelBuilder.OrderDetailSeedData();
        }

        #region Customer Seed Data
        static void CustomerSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                SampleCustomerSeedData(new Customer
                {
                    Id = 1,
                    Name = "Abanoub Makram",
                    Address = "Assuit",
                    Email = "Abanoub@gmail.com",
                    Phone = "01273925676",
                    Job = "Software Engineer",
                    DateOfBirth = new DateTime(1991, 8, 11),
                    DateCreated = DateTime.Now,
                }),
               SampleCustomerSeedData(new Customer
               {
                   Id = 2,
                   Name = "Ahmed Ali",
                   Address = "Cairo",
                   Email = "Ahmed@gmail.com",
                   Phone = "01073925676",
                   Job = "Tester Engineer",
                   DateOfBirth = new DateTime(1990, 8, 9),
                   DateCreated = DateTime.Now,
               }),
                SampleCustomerSeedData(new Customer
                {
                    Id = 3,
                    Name = "Mariam Lotfy",
                    Address = "Alex",
                    Email = "Mariam@gmail.com",
                    Phone = "01173925655",
                    Job = "Business Analyist",
                    DateOfBirth = new DateTime(2000, 8, 11),
                    DateCreated = DateTime.Now,
                }),
                 SampleCustomerSeedData(new Customer
                 {
                     Id = 4,
                     Name = "Mohammed Hussien",
                     Address = "Giz",
                     Email = "Mohammed@gmail.com",
                     Phone = "0100005676",
                     Job = "Service delivery",
                     DateOfBirth = new DateTime(1980, 8, 11),
                     DateCreated = DateTime.Now,
                 }),
                  SampleCustomerSeedData(new Customer
                  {
                      Id = 5,
                      Name = "Akram twfiq",
                      Address = "Giza",
                      Email = "Akram@gmail.com",
                      Phone = "01073929543",
                      Job = "Footballer",
                      DateOfBirth = new DateTime(1999, 10, 11),
                      DateCreated = DateTime.Now,
                  }),
                   SampleCustomerSeedData(new Customer
                   {
                       Id = 6,
                       Name = "Said Zezo",
                       Address = "Cairo",
                       Email = "Said@gmail.com",
                       Phone = "01598524676",
                       Job = "Footballer",
                       DateOfBirth = new DateTime(1995, 8, 11),
                       DateCreated = DateTime.Now,
                   })
               );
        }
        static Customer SampleCustomerSeedData(Customer customer) =>
         new Customer
         {
             Id = customer.Id,
             Name = customer.Name,
             Address = customer.Address,
             Email = customer.Email,
             Phone = customer.Phone,
             Job = customer.Job,
             DateOfBirth = customer.DateOfBirth,
             DateCreated = customer.DateCreated
         };
        #endregion

        #region Order Seed Data
        static void OrderSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                SampleOrderSeedData(new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    TotalAmount = 5000,
                    DateCreated = DateTime.Now,
                }),
                 SampleOrderSeedData(new Order
                 {
                     Id = 2,
                     CustomerId = 1,
                     TotalAmount = 10000,
                     DateCreated = DateTime.Now,
                 }),
                  SampleOrderSeedData(new Order
                  {
                      Id = 3,
                      CustomerId = 2,
                      TotalAmount = 8000,
                      DateCreated = DateTime.Now,
                  }),
                   SampleOrderSeedData(new Order
                   {
                       Id = 4,
                       CustomerId = 2,
                       TotalAmount = 3000,
                       DateCreated = DateTime.Now,
                   })
                   
              );
        }

        static Order SampleOrderSeedData(Order order) =>
        new Order
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            TotalAmount = order.TotalAmount,
            DateCreated = order.DateCreated
        };
        #endregion

        #region Order detail Seed Data
        static void OrderDetailSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasData(
                SampleOrderDetailSeedData(new OrderDetail
                {
                    Id = 1,
                    OrderId = 1,
                    Item = "Item1",
                    ItemPrice = 500,
                    NumberOfItems = 6,
                    Amount = 3000,
                    DateCreated = DateTime.Now
                }),
                 SampleOrderDetailSeedData(new OrderDetail
                 {
                     Id = 2,
                     OrderId = 1,
                     Item = "Item2",
                     ItemPrice = 200,
                     NumberOfItems = 10,
                     Amount = 2000,
                     DateCreated = DateTime.Now
                 }),
                  SampleOrderDetailSeedData(new OrderDetail
                  {
                      Id = 3,
                      OrderId = 2,
                      Item = "Item3",
                      ItemPrice = 300,
                      NumberOfItems = 6,
                      Amount = 1800,
                      DateCreated = DateTime.Now
                  }),
                   SampleOrderDetailSeedData(new OrderDetail
                   {
                       Id = 4,
                       OrderId = 2,
                       Item = "Item4",
                       ItemPrice =200 ,
                       NumberOfItems = 21,
                       Amount = 4200,
                       DateCreated = DateTime.Now
                   }),
                    SampleOrderDetailSeedData(new OrderDetail
                    {
                        Id = 5,
                        OrderId = 2,
                        Item = "Item5",
                        ItemPrice = 500,
                        NumberOfItems = 8,
                        Amount = 4000,
                        DateCreated = DateTime.Now
                    }),

                     SampleOrderDetailSeedData(new OrderDetail
                     {
                         Id = 6,
                         OrderId = 3,
                         Item = "Item6",
                         ItemPrice = 800,
                         NumberOfItems = 10,
                         Amount = 8000,
                         DateCreated = DateTime.Now
                     }),

                      SampleOrderDetailSeedData(new OrderDetail
                      {
                          Id = 7,
                          OrderId = 4,
                          Item = "Item7",
                          ItemPrice = 250,
                          NumberOfItems = 6,
                          Amount = 1500,
                          DateCreated = DateTime.Now
                      }),
                       SampleOrderDetailSeedData(new OrderDetail
                       {
                           Id = 8,
                           OrderId = 4,
                           Item = "Item8",
                           ItemPrice = 150,
                           NumberOfItems = 10,
                           Amount = 1500,
                           DateCreated = DateTime.Now
                       })
              );
        }

        static OrderDetail SampleOrderDetailSeedData(OrderDetail orderDetail) =>
        new OrderDetail
        {
            Id = orderDetail.Id,
            OrderId = orderDetail.OrderId,
            Item = orderDetail.Item,
            ItemPrice = orderDetail.ItemPrice,
            NumberOfItems = orderDetail.NumberOfItems,
            Amount = orderDetail.Amount,
            DateCreated = orderDetail.DateCreated
        };
        #endregion
    }
}
