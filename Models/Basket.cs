namespace trendyolGO.Models
{
    public class Basket
    {
        public string UserId { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
