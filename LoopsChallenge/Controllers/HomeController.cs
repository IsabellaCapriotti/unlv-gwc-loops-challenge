using LoopsChallenge.Controllers;
using LoopsChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

[Route("/")]
public class HomeController : Controller
{
    private readonly IIdentityService _identityService;

    public HomeController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = HttpContext.User;

        //_identityService.LogoutUser();
        
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
