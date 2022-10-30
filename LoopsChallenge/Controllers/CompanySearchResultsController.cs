using LoopsChallenge.Data.Entities;
using LoopsChallenge.Data.Repositories;
using LoopsChallenge.Models;

using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

[Route("results")]
public class CompanySearchResultsController : Controller
{
    private readonly ICompanyRepository _companyRepository; 

    public CompanySearchResultsController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View("Index", new CompanySearchResultsModel());
    }

    [HttpPost]
    public IActionResult ViewSearchResults([FromForm(Name = "company-search-query")] string searchQuery)
    {
        // Get companies to show
        List<Company> companiesMatchingSearch = _companyRepository.GetCompaniesMatchingName(searchQuery);

        return View("Index", new CompanySearchResultsModel { CompaniesToShow = companiesMatchingSearch, SearchQuery = searchQuery });
    }
}
