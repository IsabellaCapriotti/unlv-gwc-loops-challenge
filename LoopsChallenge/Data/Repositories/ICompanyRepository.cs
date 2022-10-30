using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Data.Repositories;

public interface ICompanyRepository
{
    public List<Company> GetCompaniesMatchingName(string companyName);

    public List<Review> GetReviewsForCompany(Guid companyId);

    public Company CreateCompany(string companyName);

    public Company GetCompanyById(Guid companyId);
}
