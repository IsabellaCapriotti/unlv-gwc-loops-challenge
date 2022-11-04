using Microsoft.AspNetCore.Mvc;
using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;

namespace LoopsChallenge.Controllers;

[Route("review")]
public class WriteReviewController : Controller
{
    private readonly ICompanyRepository _companyRepository;

    public WriteReviewController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [Route("{companyId}")]
    public async Task<IActionResult> Index([FromRoute] Guid companyId)
    {
        Company foundCompany = _companyRepository.GetCompanyById(companyId);
        return View(new WriteReviewModel { Company = foundCompany });
    }
}
