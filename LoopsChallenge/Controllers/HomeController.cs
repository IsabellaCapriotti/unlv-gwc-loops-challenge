using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using LoopsChallenge.Services;

namespace LoopsChallenge.Controllers;

[Route("/")]
public class HomeController : Controller
{
    private readonly IIdentityService _identityService;

    public HomeController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public IActionResult Index()
    {
        var user = HttpContext.User;

        if (_identityService.IsUserSignedIn(user))
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index", "SplashPage");
        }
    }
}
