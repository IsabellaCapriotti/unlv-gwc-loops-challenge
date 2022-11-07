using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LoopsChallenge.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserInfoRepository _userInfoRepository;

    public IdentityService(SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager, IUserInfoRepository userInfoRepository)
    {
        _signInManager = signinManager;
        _userManager = userManager;
        _userInfoRepository = userInfoRepository;
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

    /// <inheritdoc//>
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

    /// <inheritdoc/>
    public async Task<ProfileDetails> GetProfileDetailsForIdentityUserAsync(ClaimsPrincipal user)
    {
        IdentityUser foundUser = await _userManager.FindByNameAsync(user.Identity.Name);

        if(foundUser != null)
        {
            return await _userInfoRepository.GetProfileDetailsForIdentityUserAsync(foundUser);
        }
        return null;
    }

    /// <inheritdoc/>
    public async Task<IdentityUser> GetIdentityUserAsync(ClaimsPrincipal user)
    {
        return await _userManager.FindByNameAsync(user.Identity.Name);
    }

}
