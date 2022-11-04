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

    /// <summary>
    /// Creates an IdentityUser instance in the database for the passed email and password. If the creation succeeded,
    /// it will return a reference to the new IdentityUser. If it failed, it will return null. 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<IdentityUser?> CreateUserAsync(string username, string password) 
    {
        IdentityUser newUser = new IdentityUser();
        newUser.UserName = username;
        newUser.Email = username;

        var res = await _userManager.CreateAsync(newUser, password);

        if (res.Succeeded)
        {
            return newUser;
        }
        else
        {
            return null;
        }
    }

    public async Task LogoutUser() {
        await _signInManager.SignOutAsync();
    }

}
