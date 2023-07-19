using trendyolGO.Models;

namespace trendyolGO.Services;

public interface IUserService
{
    public Task<List<UserResponse>>GetAllUsersByRole(int role);
}

