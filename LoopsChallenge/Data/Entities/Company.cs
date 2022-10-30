using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoopsChallenge.Data.Entities;

public class Company
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    public string CompanyDisplayName { get; set; }
    
    public string CompanyNormalizedName { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
}
