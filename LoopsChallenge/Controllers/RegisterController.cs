using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;
using LoopsChallenge.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LoopsChallenge.Controllers;

[Route("register")]
public class RegisterController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IUserInfoRepository _userInfoRepository;
    
    public RegisterController(IIdentityService identityService, IUserInfoRepository userInfoRepository)
    {
        _identityService = identityService;
        _userInfoRepository = userInfoRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new RegisterModel());
    }

    [HttpPost]
    public async Task<IActionResult> SubmitRegistration(RegisterModel registrationInfo)
    {
        System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(registrationInfo));

        if(!String.IsNullOrEmpty(registrationInfo.Email) && !String.IsNullOrEmpty(registrationInfo.Password))
        {
            // Create user in Identity
            IdentityUser? newIdentityUser = await _identityService.CreateUserAsync(registrationInfo.Email, registrationInfo.Password);

            // Associate profile details with Identity user
            if(newIdentityUser != null)
            {
                UserInfo newUserInfo = new UserInfo
                {
                    IdentityUser = newIdentityUser,
                    IdentityUserId = newIdentityUser.Id,
                    ProfileDetails = new ProfileDetails
                    {
                        DisplayName = registrationInfo.DisplayName,
                        Gender = registrationInfo.Gender,
                        Race = registrationInfo.Race,
                        HispanicLatino = registrationInfo.HispanicLatino,
                        Location = registrationInfo.Location,
                        Bio = registrationInfo.Bio,
                    }
                };

                await _userInfoRepository.AddUserInfoAsync(newUserInfo);
            }

            // Sign in and redirect to homepage
            await _identityService.LoginUserIfExistsAsync(registrationInfo.Email, registrationInfo.Password);
            return RedirectToAction("Index", "Home");
        }
        

        return View("Index", new RegisterModel());
    }

    // TODO: Send an AJAX call to this endpoint when they enter an email to make sure it's available
    [HttpPost]
    [Route("/checkemailavailability")]
    public IActionResult CheckEmailAvailability()
    {
        return View("Index");
    }
}
