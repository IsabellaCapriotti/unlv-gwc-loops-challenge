using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LoopsChallenge.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public IdentityService(SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signinManager;
        _userManager = userManager;
    }

    public bool IsUserSignedIn(ClaimsPrincipal user)
    {
        return _signInManager.IsSignedIn(user);
    }

    public async Task<bool> LoginUserIfExistsAsync(string username, string password)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(username, password, true, false);

        return signInResult.Succeeded;
    }

    public async Task<bool> CreateUserAsync(string username, string password) { return false;  }

    public void LogoutUser() { }

}
