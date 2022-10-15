using Microsoft.AspNetCore.Mvc;
using LoopsChallenge.Models;
using System.Text.Json; 

namespace LoopsChallenge.Controllers;

[Route("register")]
public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new RegisterControllerModel());
    }

    [HttpPost]
    public IActionResult SubmitRegistration(RegisterControllerModel registrationInfo)
    {
        System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(registrationInfo));
        return View("Index", new RegisterControllerModel());
    }
}
