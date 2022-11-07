using LoopsChallenge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LoopsChallenge.Services;

public interface IIdentityService
{
    public bool IsUserSignedIn(ClaimsPrincipal user);
    public Task<bool> LoginUserIfExistsAsync(string username, string password);
    public Task LogoutUser();


    /// <summary>
    /// Creates an IdentityUser instance in the database for the passed email and password. If the creation succeeded,
    /// it will return a reference to the new IdentityUser. If it failed, it will return null. 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public Task<IdentityUser?> CreateUserAsync(string username, string password);


    /// <summary>
    /// Given a User created through the Identity library, returns the profile details associated with that user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<ProfileDetails> GetProfileDetailsForIdentityUserAsync(ClaimsPrincipal user);

    /// <summary>
    /// Given an authenticated user, return the IdentityUser associated with them.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<IdentityUser> GetIdentityUserAsync(ClaimsPrincipal user);
}
