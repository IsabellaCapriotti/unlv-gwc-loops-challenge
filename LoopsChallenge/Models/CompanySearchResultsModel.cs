using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Models;

public class CompanySearchResultsModel
{
    public string SearchQuery { get; set; }

    public List<Company> CompaniesToShow { get; set; } = new List<Company>();
}
