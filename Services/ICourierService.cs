using trendyolGO.Models;
namespace trendyolGO.Services;

    public interface ICourierService
    {
    public Task<List<CourierResponse>> GetAllCouriersByRole(int role);
    }

