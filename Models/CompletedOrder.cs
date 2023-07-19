namespace trendyolGO.Models
{
    public class CompletedOrder
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
