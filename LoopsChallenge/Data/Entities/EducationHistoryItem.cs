using System.ComponentModel.DataAnnotations;

namespace LoopsChallenge.Data.Entities;

public class EducationHistoryItem
{
    [Key]
    public int Id { get; set; }

    public string SchoolName { get; set; }
    public string Major { get; set; }
    public DateTime GraduationDate { get; set; }
    public bool IsCurrent { get; set; } = false;
    public string? Details { get; set; }
}
