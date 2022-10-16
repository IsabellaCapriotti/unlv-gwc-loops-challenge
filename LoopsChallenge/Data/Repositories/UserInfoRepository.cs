using LoopsChallenge.Data.Entities;

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
}
