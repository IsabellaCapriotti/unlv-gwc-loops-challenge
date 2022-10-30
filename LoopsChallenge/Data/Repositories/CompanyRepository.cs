using LoopsChallenge.Data.Entities; 

namespace LoopsChallenge.Data.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _dbContext; 

    public CompanyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Company> GetCompaniesMatchingName(string companyName)
    {
        return _dbContext.Company.Where(c => c.CompanyNormalizedName.Contains(companyName.ToLowerInvariant()) || companyName.ToLowerInvariant().Contains(c.CompanyNormalizedName) )
        .ToList();
    }

    public List<Review> GetReviewsForCompany(Guid companyId)
    {
        return _dbContext.Review.Where(r => r.CompanyId == companyId).ToList();
    }

    public Company CreateCompany(string companyName)
    {
        Company company = new Company
        {
            CompanyDisplayName = companyName,
            CompanyNormalizedName = companyName.ToUpperInvariant(),
            Id = Guid.NewGuid()
        };

        _dbContext.Company.Add(company);
        _dbContext.SaveChanges();

        return company;
    }

    public Company GetCompanyById(Guid companyId)
    {
        return _dbContext.Company.Find(companyId);
    }

}
