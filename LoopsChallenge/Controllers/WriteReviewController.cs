using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

public class WriteReviewController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
