using System.ComponentModel.DataAnnotations;

namespace LoopsChallenge.Data.Entities;

public class ProfileDetails
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? DisplayName { get; set; }
   
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public bool? HispanicLatino { get; set; } = false;
    public string? Location { get; set; }
    public string? Bio { get; set; }
}
