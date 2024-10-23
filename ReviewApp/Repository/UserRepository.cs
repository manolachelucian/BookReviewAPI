using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DataContext dataContex;

        public UserRepository(DataContext dataContex)
        {
            this.dataContex = dataContex;
        }

        public ICollection<Review> GetReviewsByUser(int IdUser)
        {
            return dataContex.Reviews.Where(r => r.UserId == IdUser).ToList();
        }

        public User GetUser(int id)
        {
            return dataContex.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return dataContex.Users.OrderBy(u => u.Username).ToList();
        }

        public bool UserExists(int id)
        {
            return dataContex.Users.Any(u => u.Id == id);
        }
    }
}
