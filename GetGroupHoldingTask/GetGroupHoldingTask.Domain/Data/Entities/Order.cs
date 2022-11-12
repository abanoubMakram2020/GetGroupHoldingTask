namespace GetGroupHoldingTask.Domain.Data.Entities
{
    public class Order : BaseEntity<int>
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        //  public DateTime Date        { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual HashSet<OrderDetail> OrderDetails { get; set; }
    }
}
