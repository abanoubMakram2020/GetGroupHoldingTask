using GetGroupHoldingTask.Domain.Data.Entities;
using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;


namespace GetGroupHoldingTask.Application.DTOs.InputDTOs
{
    public class CustomerSearchInputDTO
    {
        public string? CustomerName { get; set; }
        public StringSearchOperator? CustomerNameSearchOperator { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateSearchOperator? DateOfBirthSearchOperator { get; set; }
        public string? Job { get; set; }
        public StringSearchOperator? JobSearchOperator { get; set; }
        public string? Address { get; set; }
        public StringSearchOperator? AddressSearchOperator { get; set; }
        public string? Phone { get; set; }
        public StringSearchOperator? PhoneSearchOperator { get; set; }
        public string?    Email { get; set; }
        public StringSearchOperator? EmailSearchOperator { get; set; }
        public int? NumberOfOrders { get; set; }
        public NumbersSearchOperator? NumberOfOrdersSearchOperator { get; set; }
        public decimal? TotalAmountOfTotalOrders { get; set; }
        public NumbersSearchOperator? TotalAmountOfTotalOrdersSearchOperator { get; set; }
        public OrderEnum OrderType { get; set; } = OrderEnum.Asc;
    }
}
