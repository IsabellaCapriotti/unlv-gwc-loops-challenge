using System.ComponentModel.DataAnnotations;

namespace LoopsChallenge.Data.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }

    public string TagText { get; set; }

    public string NormalizedTagText { get; set; }

    public bool IsDefaultSuggested { get; set; } = false;
}
