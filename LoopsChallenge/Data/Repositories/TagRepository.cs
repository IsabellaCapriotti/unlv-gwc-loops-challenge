using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data;

namespace LoopsChallenge.Data.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _dbContext; 

    public TagRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Tag> GetDefaultSuggestedTags()
    {
        return _dbContext.Tag.Where(t => t.IsDefaultSuggested == true).ToList();
    }

    public List<Tag> GetCustomSuggestedTags(ProfileDetails profileDetails)
    {
        List<Tag> allTags = _dbContext.Tag.ToList();

        return allTags.Where(t => t.NormalizedTagText.Contains(profileDetails.Gender ?? "", StringComparison.InvariantCultureIgnoreCase)
        || t.NormalizedTagText.Contains(profileDetails.Race ?? "", StringComparison.InvariantCultureIgnoreCase)
        || t.NormalizedTagText.Contains(profileDetails.Location ?? "", StringComparison.InvariantCultureIgnoreCase)
        || (profileDetails.Bio ?? "").Contains(t.NormalizedTagText, StringComparison.InvariantCultureIgnoreCase)
        || (t.NormalizedTagText.Contains("latinx", StringComparison.InvariantCultureIgnoreCase) && (profileDetails.HispanicLatino ?? false))
        ).ToList();
    }

    public List<Tag> GetAllTags()
    {
        return _dbContext.Tag.ToList();
    }

    public async Task<Tag?> GetTagByTextIfExistsAsync(string text)
    {
        return await _dbContext.Tag.FindAsync(text);
    }

    public async Task<Tag> AddTagAsync(Tag newTag)
    {
        await _dbContext.Tag.AddAsync(newTag);
        return newTag;
    }
}
