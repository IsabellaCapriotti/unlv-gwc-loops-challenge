using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoopsChallenge.Data.Entities;

public class UserInfo
{
    [Key]
    public int Id { get; set; }

    public IdentityUser IdentityUser { get; set; } = null;
    [ForeignKey("IdentityUser")]
    [Required]
    public string IdentityUserId { get; set; }

    public ProfileDetails ProfileDetails { get; set; } = null;
    [ForeignKey("ProfileDetails")]
    [Required]
    public int ProfileDetailsId { get; set; }

}

