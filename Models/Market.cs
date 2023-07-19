using MongoDB.Bson.Serialization.Attributes;

namespace trendyolGO.Models;

public class Market
{
    [BsonId]
    public int MarketId { get; set; }
    [BsonElement("marketname")]
    public string MarketName { get; set; }
    [BsonElement("marketaddress")]
    public string MarketAdress { get; set; }
    [BsonElement("marketproduct")]
    public string MarketProduct { get; set; }
    [BsonElement("marketproductcount")]
    public string MarketProductCount { get; set;}
}

public class MarketResponse
{
    public int MarketId { get; set; }
    public string MarketName { get; set; }
    public string MarketAdress { get; set; }
}

