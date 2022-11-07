using Microsoft.AspNetCore.Mvc;
using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;
using LoopsChallenge.Services;
using System.Text.Json;

namespace LoopsChallenge.Controllers;

[Route("review")]
public class WriteReviewController : Controller
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IIdentityService _identityService; 

    private readonly List<Tag> _defaultSuggestedTags;

    public WriteReviewController(ICompanyRepository companyRepository, ITagRepository tagRepository, IUserInfoRepository userInfoRepository,
        IReviewRepository reviewRepository, IIdentityService identityService)
    {
        _companyRepository = companyRepository;
        _tagRepository = tagRepository;
        _userInfoRepository = userInfoRepository;
        _reviewRepository = reviewRepository;
        _identityService = identityService;

        _defaultSuggestedTags = tagRepository.GetDefaultSuggestedTags();
    }

    [HttpGet]
    [Route("{companyId}")]
    public async Task<IActionResult> Index([FromRoute] Guid companyId)
    {
        Company foundCompany = _companyRepository.GetCompanyById(companyId);
        ProfileDetails userProfileDetails = await _identityService.GetProfileDetailsForIdentityUserAsync(HttpContext.User);

        List<Tag> tagsToSuggest = _defaultSuggestedTags.Concat(_tagRepository.GetCustomSuggestedTags(userProfileDetails)).DistinctBy(t => t.NormalizedTagText).ToList();

        return View(new WriteReviewModel { Company = foundCompany, SuggestedTags = tagsToSuggest });
    }

    [HttpPost]
    [Route("{companyId}")]
    public async Task<IActionResult> SubmitReview(WriteReviewModel model, [FromRoute] Guid companyId)
    {
        Review newReview = new Review
        {
            CompanyId = companyId,
            User = await _identityService.GetIdentityUserAsync(HttpContext.User),
            ReviewText = model.ReviewContent,
            SerializedTags = JsonSerializer.Serialize(model.ChosenTags),
            Rating = model.StarRating + 1
        };

        _reviewRepository.CreateReview(newReview);

        return RedirectToAction("Index", "CompanyPage", new RouteValueDictionary { { "companyId", companyId } }); 
    }
}
