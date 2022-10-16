using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Data.Repositories;

public interface IUserInfoRepository
{
    public Task<UserInfo> AddUserInfoAsync(UserInfo newUserInfo);
}
