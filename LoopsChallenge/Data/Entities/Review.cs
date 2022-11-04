using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoopsChallenge.Data.Entities;

public class Review
{
    [Key]
    public int Id { get; set; }

    public Company Company { get; set; }
    [ForeignKey("Company")]
    public Guid CompanyId { get; set; }

    public IdentityUser User { get; set; }
    [ForeignKey("User")]
    public string UserId { get; set; }

    public string ReviewText { get; set; }

    public string SerializedTags { get; set; }

    [Range(1,10)]
    public int Rating { get; set; }
}
