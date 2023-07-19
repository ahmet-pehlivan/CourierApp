namespace trendyolGO.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
