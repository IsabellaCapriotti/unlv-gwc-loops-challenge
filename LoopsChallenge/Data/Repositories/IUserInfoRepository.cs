using LoopsChallenge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LoopsChallenge.Data.Repositories;

public interface IUserInfoRepository
{
    public Task<UserInfo> AddUserInfoAsync(UserInfo newUserInfo);

    public Task<ProfileDetails> GetProfileDetailsForIdentityUserAsync(IdentityUser identityUser);
}
