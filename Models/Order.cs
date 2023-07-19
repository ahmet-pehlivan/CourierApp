using MongoDB.Bson.Serialization.Attributes;

namespace trendyolGO.Models;


public class Order
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string OrderCode { get; set; }
    public Basket Basket { get; set; }
    public CompletedOrder CompletedOrder { get; set; }
}
//    [BsonId]
//    public int OrderId { get; set; }
//    [BsonElement("orderproducts")]
//    public string OrderProducts { get; set; }
//    [BsonElement("ordercount")]
//    public int OrderCount { get; set; }
//    [BsonElement("amount")]
//    public int Amount { get; set; }
//}
//public class OrderRequest
//{
//    public int OrderId { get; set; }
//    public string OrderProducts { get; set; }
//    public int OrderCount { get; set; }
//    public int Amount { get; set; }
//}
//public class OrderResponse
//{
//    public int OrderId { get; set; }
//    public string OrderProducts { get; set; }
//    public int OrderCount { get; set; }
//    public int Amount { get; set; }
//}

