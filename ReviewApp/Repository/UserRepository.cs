using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    /// <summary>
    /// Repository implementation for user-related operations.
    /// </summary>
    public class UserRepository : IUserInterface
    {
        private readonly DataContext dataContext;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dataContext">The data context for accessing the database.</param>
        public UserRepository(DataContext dataContex)
        {
            this.dataContext = dataContex;
        }


        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user object to be created.</param>
        /// <returns>True if the user is created successfully, otherwise false.</returns>
        public bool CreateUser(User user)
        {
            dataContext.Users.Add(user);

            return Save();
        }
        /// <summary>
        /// Deletes an existing user from the database.
        /// </summary>
        /// <param name="user">The user object to be deleted.</param>
        /// <returns>True if the user is deleted successfully, otherwise false.</returns>
        public bool DeleteUser(User user)
        {
            dataContext.Remove(user);
            return Save();
        }



        /// <summary>
        /// Retrieves all reviews written by a specific user.
        /// </summary>
        /// <param name="IdUser">The ID of the user whose reviews are to be fetched.</param>
        /// <returns>A collection of reviews written by the user.</returns>
        public ICollection<Review> GetReviewsByUser(int IdUser)
        {
            return dataContext.Reviews.Where(r => r.UserId == IdUser).ToList();
        }

        /// <summary>
        /// Retrieves a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user object if found, otherwise null.</returns>
        public User GetUser(int id)
        {
            return dataContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A collection of all users, ordered by their username.</returns>
        public ICollection<User> GetUsers()
        {
            return dataContext.Users.OrderBy(u => u.Username).ToList();
        }


        /// <summary>
        /// Saves all changes made to the data context.
        /// </summary>
        /// <returns>True if changes are saved successfully, otherwise false.</returns>
        public bool Save()
        {
            var save = dataContext.SaveChanges();
            return save > 0 ? true : false;
        }


        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">The user object containing updated details.</param>
        /// <returns>True if the user is updated successfully, otherwise false.</returns>

        public bool UpdateUser(User user)
        {
            dataContext.Users.Update(user);
            return Save();
        }



        /// <summary>
        /// Checks if a user exists by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>True if the user exists, otherwise false.</returns>
        public bool UserExists(int id)
        {
            return dataContext.Users.Any(u => u.Id == id);
        }



        
    }
}
