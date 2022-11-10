using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Models;

public class CompanyPageModel
{
    public Company Company { get; set; }

    public List<Review> Reviews { get; set; }

    public List<Tag> SuggestedTags { get; set; }
}
