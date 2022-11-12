namespace GetGroupHoldingTask.Domain.Data.Entities
{
    public class OrderDetail : BaseEntity<int>
    {
        public int    OrderId        { get; set; }
        public string  Item          { get; set; }
        public decimal ItemPrice     { get; set; }
        public int     NumberOfItems { get; set; }
        public decimal Amount        { get; set; }
        public Order Order { get; set; }

    }
}
