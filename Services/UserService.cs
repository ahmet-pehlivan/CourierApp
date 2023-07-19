using Microsoft.Extensions.Options;
using MongoDB.Driver;
using trendyolGO.Models;
using MongoDB.Driver.Linq;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace trendyolGO.Services;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    public UserService(UserManager<AppUser> userManager, Context context)
    {
        _userManager = userManager;
        _context = context;
    }

    private readonly Context _context = null;
    public UserService(IOptions<Settings> settings)
    {
        _context = new Context(settings);
    }
    public async Task AssignRoleToUserAsync(string userId, string[] roles)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, roles);
        }
    }
    public async Task<string[]> GetRolesToUsersAsync(string userIdOrName)
    {
        AppUser user = await _userManager.FindByNameAsync(userIdOrName);

        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(userIdOrName);
        }
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }
        return new string[] { };
    }


    public async Task<List<UserResponse>> GetAllUsersByRole(int role)
    {
        try
        {
            var users = _context.Users.AsQueryable()
                .Where(x => x.Role == role)
                .Select(x => new UserResponse
                {
                    Id = x.Id,
                    Username = x.Username,
                }).ToList();
            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
    public async Task<List<UserResponse>> GetUserAddressById(int Id)
    {
        try
        {
            var users = _context.Users.AsQueryable()
                .Where(x => x.Id == Id)
                .Select(x => new UserResponse
                {
                    Id = x.Id,
                    UserAdress = x.UserAddress,
                }).ToList();
            return users;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}




