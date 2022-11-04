namespace LoopsChallenge.Data.Entities;

public class Tag
{
    public int Id { get; set; }

    public string TagText { get; set; }

    public string NormalizedTagText { get; set; }

    public bool IsDefaultSuggested { get; set; } = false;
}
