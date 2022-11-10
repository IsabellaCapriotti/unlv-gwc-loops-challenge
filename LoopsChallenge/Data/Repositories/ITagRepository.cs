using LoopsChallenge.Data.Entities; 

namespace LoopsChallenge.Data.Repositories;

public interface ITagRepository
{
    public List<Tag> GetDefaultSuggestedTags();

    public List<Tag> GetCustomSuggestedTags(ProfileDetails profileDetails);

    public Task<Tag?> GetTagByTextIfExistsAsync(string text);

    public Task<Tag> AddTagAsync(Tag newTag);
}
