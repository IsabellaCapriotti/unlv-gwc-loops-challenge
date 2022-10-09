using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

[Route("register")]
public class RegisterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
