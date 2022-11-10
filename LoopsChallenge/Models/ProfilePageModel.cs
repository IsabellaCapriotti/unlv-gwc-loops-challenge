using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Models;

public class ProfilePageModel
{
    public string Username { get; set; }
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public bool? Ethnicity { get; set; }
    public string? Location { get; set; }
    public string? Bio { get; set; }
}