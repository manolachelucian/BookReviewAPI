using ReviewApp.Models;

namespace ReviewApp.Interface
{
    public interface IReviewInterface
    {
        ICollection<Review> GetAllReviews();

        Review GetReview(int id);

        bool ReviewExists(int id);

        bool DeleteReview(int id);

        bool UpdateReview(Review review);

        bool AddReview(Review review);

        bool Save();

    }
}
