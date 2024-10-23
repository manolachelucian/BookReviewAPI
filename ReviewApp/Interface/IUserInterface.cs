using ReviewApp.Models;

namespace ReviewApp.Interface
{
    public interface IUserInterface 

    {

        ICollection<User> GetUsers();

        User GetUser(int id);

        ICollection<Review> GetReviewsByUser(int IdUser);

        bool UserExists(int id);

    }
}
