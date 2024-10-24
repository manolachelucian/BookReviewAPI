using ReviewApp.Data;

using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ReviewRepository : IReviewInterface
    {
        private readonly DataContext dataContext;

        public ReviewRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetAllReviews()
        {
            return dataContext.Reviews.OrderBy(r => r.Id).ToList();
        }

        public Review GetReview(int id)
        {
            return dataContext.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool ReviewExists(int id)
        {
            return dataContext.Reviews.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var save = dataContext.SaveChanges();
            return save > 0 ? true : false;
            
        }

        public bool UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
