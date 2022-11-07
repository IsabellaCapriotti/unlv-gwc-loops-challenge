using LoopsChallenge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LoopsChallenge.Data.Repositories;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserInfoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserInfo> AddUserInfoAsync(UserInfo newUserInfo)
    {
        await _dbContext.UserInfo.AddAsync(newUserInfo);
        _dbContext.SaveChanges();

        return newUserInfo;
    }

    public async Task<ProfileDetails> GetProfileDetailsForIdentityUserAsync(IdentityUser identityUser)
    { 
        UserInfo foundUserInfo =  _dbContext.UserInfo.Where(u => u.IdentityUserId == identityUser.Id).FirstOrDefault();

        if(foundUserInfo != null)
        {
            return await _dbContext.ProfileDetails.FindAsync(foundUserInfo.ProfileDetailsId);
        }
        return null;
    }
}
