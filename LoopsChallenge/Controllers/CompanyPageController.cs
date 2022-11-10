using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;
using LoopsChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

[Route("company")]
public class CompanyPageController : Controller
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IIdentityService _identityService;

    private readonly IList<Tag> _defaultSuggestedTags;

    public CompanyPageController(ICompanyRepository companyRepository, ITagRepository tagRepository, IIdentityService identityService)
    {
        _companyRepository = companyRepository;
        _tagRepository = tagRepository;
        _identityService = identityService;
        _defaultSuggestedTags = _tagRepository.GetDefaultSuggestedTags();
    }

    [HttpGet]
    [Route("/company/{companyId}")]
    public async Task<IActionResult> Index([FromRoute] Guid companyId)
    {
        Company matchingCompany = _companyRepository.GetCompanyById(companyId);

        if(matchingCompany == null)
        {
            return RedirectToAction("Error");
        }

        List<Review> companyReviews = _companyRepository.GetReviewsForCompany(companyId);
        ProfileDetails userProfileDetails = await _identityService.GetProfileDetailsForIdentityUserAsync(HttpContext.User);

        List<Tag> tagsToSuggest = _defaultSuggestedTags.Concat(_tagRepository.GetCustomSuggestedTags(userProfileDetails)).DistinctBy(t => t.NormalizedTagText).ToList();

        return View("Index", new CompanyPageModel { Company = matchingCompany, Reviews = companyReviews, SuggestedTags = tagsToSuggest });
    }

    [HttpGet]
    [Route("/company/newCompany")]
    public IActionResult NewCompany([FromQuery(Name = "newCompanyName")] string newCompanyName)
    {
        // Check for any false new creations
        List<Company> matchingCompanies = _companyRepository.GetCompaniesMatchingName(newCompanyName);
        if (matchingCompanies.Count != 0)
        {
            return Redirect("/company/" + matchingCompanies.First().Id);
        }

        // If this is the first time this company has been visited, generate a new Company
        Company newCompany = _companyRepository.CreateCompany(newCompanyName);
        return Redirect("/company/" + newCompany.Id.ToString());
    }

    [HttpGet]
    [Route("/company/error")]
    public IActionResult Error()
    {
        return View("Error");
    }

}
