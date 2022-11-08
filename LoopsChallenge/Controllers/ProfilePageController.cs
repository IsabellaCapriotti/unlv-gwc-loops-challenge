using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;
using LoopsChallenge.Services;
using Microsoft.AspNetCore.Mvc;

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
}

///*namespace LoopsChallenge.Controllers
///{
///    public class ProfileController : Controller
 ///   {
///        public IActionResult Index()
///        {
///            return View();
///        }
///    }
///}
