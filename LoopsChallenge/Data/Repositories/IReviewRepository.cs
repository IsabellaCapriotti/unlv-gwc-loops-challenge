using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Data.Repositories;

public interface IReviewRepository
{
    public Review CreateReview(Review review);
}
