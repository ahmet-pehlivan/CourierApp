using trendyolGO.Models;

namespace trendyolGO.Services
{
    public interface IAuthService
    {
        public Task<User> Authenticate(LoginRequest request);
    }
}
