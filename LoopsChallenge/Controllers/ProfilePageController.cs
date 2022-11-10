using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;
using LoopsChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using LoopsChallenge.Controllers;
using Microsoft.AspNetCore.Identity;

namespace LoopsChallenge.Controllers;

[Route("profile")]

public class ProfilePageController : Controller
{
    ///get user shtuff from ProfileDetails
    private readonly IIdentityService _identityService;

    public ProfilePageController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet]

    public async Task<IActionResult> Index()
    {
        var user = HttpContext.User;

        if (_identityService.IsUserSignedIn(user))
        {
            ProfileDetails foundUser = await _identityService.GetProfileDetailsForIdentityUserAsync(user);
            //this is where you get the info for the user?
            return View(new ProfilePageModel {Username = foundUser.DisplayName});
        }
        else
        {
            //if the user is not signed in I was thinking to redirect to splash page
            return RedirectToAction("Index", "Splashpage");
        }

    }
}
