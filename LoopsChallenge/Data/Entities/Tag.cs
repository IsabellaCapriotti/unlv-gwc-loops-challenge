using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoopsChallenge.Data.Entities;

public class Tag
{
    public string DisplayTagText { get; set; }

    private string _normalized;

    [Key]
    public string NormalizedTagText
    {
        get => _normalized;

        set => _normalized = value.ToLowerInvariant();
    }

    public bool IsDefaultSuggested { get; set; } = false;
}
