using LoopsChallenge.Data.Entities; 

namespace LoopsChallenge.Models;

public class WriteReviewModel
{
    public Company Company { get; set; }

    public Review Review { get; set; } = new();

    public List<Tag> SuggestedTags { get; set; } = new();
}
