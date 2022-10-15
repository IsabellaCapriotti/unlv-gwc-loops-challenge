﻿using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Models;

public class RegisterControllerModel
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string ProfileImage { get; set; } = "";

    public string DisplayName { get; set; } = "";
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public bool? HispanicLatino { get; set; }
    public string? Location { get; set; }
    public string? Bio { get; set; }
}
