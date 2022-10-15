using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LoopsChallenge.Services;

namespace LoopsChallenge.Controllers;

[Route("/welcome")]
public class SplashPageController : Controller
{
    private readonly IIdentityService _identityService;

    public SplashPageController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewData["needsRegistration"] = false;
        return View("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm(Name = "username-input")] string username, [FromForm(Name = "password-input")] string password)
    {
        // Validate form 
        if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
        {
            ViewData["errorMessage"] = "Please enter a username and password.";
            return View("Index");
        }

        bool loginSucceeded = await _identityService.LoginUserIfExistsAsync(username, password);

        if (loginSucceeded)
        {
            return RedirectToAction("Index", "Home");
        }

        else
        {
            ViewData["needsRegistration"] = true;
            System.Diagnostics.Debug.WriteLine("setting needsregistration to true");
            return View("Index");
        }
    }
}
