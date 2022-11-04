using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LoopsChallenge.Services;

public interface IIdentityService
{
    public bool IsUserSignedIn(ClaimsPrincipal user);
    public Task<bool> LoginUserIfExistsAsync(string username, string password);
    public Task<IdentityUser?> CreateUserAsync(string username, string password);
    public Task LogoutUser();
}
