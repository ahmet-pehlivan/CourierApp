using MongoDB.Bson.Serialization.Attributes;

namespace trendyolGO.Models;

public class User
{
    [BsonId]
    public int Id { get; set; }
    [BsonElement("username")]
    public string Username { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
    [BsonElement("role")]
    public int Role { get; set; }
    [BsonElement("useraddress")]
    public string UserAddress { get; set; }


}

public enum AppRole
{
    Admin = 1,
    User = 0
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string UserAdress { get; set; }
    public int Role { get; set; }
}
