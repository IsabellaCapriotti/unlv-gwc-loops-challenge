namespace LoopsChallenge.Data.Entities;

public class EmploymentHistoryItem
{
    public string Employer { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCurrent { get; set; } = false;
    public string? Details { get; set; }
}
