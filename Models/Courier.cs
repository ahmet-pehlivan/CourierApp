using MongoDB.Bson.Serialization.Attributes;

namespace trendyolGO.Models;

public class Courier
{
    [BsonId]
    public int CourierId { get; set; }
    [BsonElement("couriername")]
    public string CourierName { get; set; }
    [BsonElement("courierpassword")]
    public string CourierPassword { get; set; }
    [BsonElement("courieraddress")]
    public string CourierAddress { get; set; }
    [BsonElement("role")]
    public int Role { get; set; }

}
public enum CourierRole
{
    Admin = 1,
    Courier = 0,
}
public class LoginRequestCourier
{
    public string CourierUserName { get; set; }
    public string CourierPassword { get; set; }
}

public class CourierResponse
{
    public int Role { get; set; }
    public int CourierId { get; set; }
    public int CourierRange { get; set; }
    public bool CourierSituation { get; set; }
}

