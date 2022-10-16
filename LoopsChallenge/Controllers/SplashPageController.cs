using LoopsChallenge.Services;
using Microsoft.AspNetCore.Mvc;

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
        // Redirect to homepage if already logged in 
        if (_identityService.IsUserSignedIn(HttpContext.User))
        {
            return RedirectToAction("Index", "Home");
        }

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
            return View("Index");
        }
    }
}
