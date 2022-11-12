﻿namespace GetGroupHoldingTask.Domain.Data.Entities
{
    public class Customer : BaseEntity<int>
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual HashSet<Order> Orders { get; set; }

    }
}
