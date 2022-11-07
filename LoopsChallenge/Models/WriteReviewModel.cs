using LoopsChallenge.Data.Entities; 

namespace LoopsChallenge.Models;

public class WriteReviewModel
{
    public Company Company { get; set; }

    public List<Tag> SuggestedTags { get; set; } = new();

    public List<string>? ChosenTags { get; set; } = new();

    public string ReviewContent { get; set; } = "";

    public int StarRating { get; set; }
}
