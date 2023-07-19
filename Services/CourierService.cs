using Microsoft.Extensions.Options;
using MongoDB.Driver;
using trendyolGO.Models;

namespace trendyolGO.Services;

public class CourierService : ICourierService
{
    private readonly Context _context = null;

    public CourierService(IOptions<Settings> settings)
    {
        _context = new Context(settings);
    }
    public async Task<List<CourierResponse>> GetAllCouriersByRole(int role)
    {
        try
        {
            var couriers = _context.Couriers.AsQueryable()
                .Where(x => x.Role == role)
                .Select(x => new CourierResponse
                {
                    CourierId = x.CourierId,

                    
                }).ToList();

            return couriers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}


