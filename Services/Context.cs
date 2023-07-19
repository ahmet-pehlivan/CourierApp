using Microsoft.Extensions.Options;
using MongoDB.Driver;
using trendyolGO.Models;

namespace trendyolGO.Services
{
    public class Context
    {
        private readonly IMongoDatabase _database = null;
        public Context(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client == null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("user");
            }
        }
        public IMongoCollection<Courier> Couriers
        {
            get
            {
                return _database.GetCollection<Courier>("courier");
            }
        }
        public IMongoCollection<Market> Markets
        {
            get
            {
                return _database.GetCollection<Market>("market");
            }
        }
        public IMongoCollection<Order> Orders
        {
            get
            {
                return _database.GetCollection<Order>("order");
            }
        }
    }
}
