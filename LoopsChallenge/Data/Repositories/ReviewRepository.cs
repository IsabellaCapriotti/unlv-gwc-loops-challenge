using LoopsChallenge.Data.Entities; 

namespace LoopsChallenge.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ReviewRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Review CreateReview(Review newReview)
    {
        _dbContext.Review.Add(newReview);
        _dbContext.SaveChanges();

        return newReview;
    }
}
