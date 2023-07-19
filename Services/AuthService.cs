using Auth0.ManagementApi.Models.Rules;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using trendyolGO.Models;
using LoginRequest = trendyolGO.Models.LoginRequest;

namespace trendyolGO.Services;

public class AuthService : IAuthService
{
    private readonly Context _context;

    public AuthService(IOptions<Settings> settings)
    {
        _context = new Context(settings);
    }
    public async Task<User> Authenticate(LoginRequest request)
    {
        return await _context.Users.Find(x => x.Username == request.Username).FirstOrDefaultAsync();

    }

}

