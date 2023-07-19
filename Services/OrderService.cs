using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using trendyolGO.Models;

namespace trendyolGO.Services;

public class OrderService : IOrderService
{
    private readonly Context _context = null;

    public OrderService(IOptions<Settings> settings)
    {
        _context = new Context(settings);
    }

    
   
}