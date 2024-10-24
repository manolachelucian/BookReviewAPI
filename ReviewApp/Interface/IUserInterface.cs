using ReviewApp.Models;

namespace ReviewApp.Interface
{
    /// <summary>
    /// Interface defining the operations for managing users in the system.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Gets a collection of all users.
        /// </summary>
        /// <returns>A collection of users.</returns>
        ICollection<User> GetUsers();

        /// <summary>
        /// Gets a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user object corresponding to the specified ID.</returns>
        User GetUser(int id);

        /// <summary>
        /// Gets all reviews written by a specific user.
        /// </summary>
        /// <param name="IdUser">The ID of the user whose reviews are to be retrieved.</param>
        /// <returns>A collection of reviews written by the user.</returns>
        ICollection<Review> GetReviewsByUser(int IdUser);

        /// <summary>
        /// Checks if a user exists by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>True if the user exists, false otherwise.</returns>
        bool UserExists(int id);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user object containing user details to be created.</param>
        /// <returns>True if the user is successfully created, false otherwise.</returns>
        bool CreateUser(User user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user">The user object to be deleted.</param>
        /// <returns>True if the user is successfully deleted, false otherwise.</returns>
        bool DeleteUser(User user);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user object containing updated details.</param>
        /// <returns>True if the user is successfully updated, false otherwise.</returns>
        bool UpdateUser(User user);

        /// <summary>
        /// Saves all changes to the data context.
        /// </summary>
        /// <returns>True if changes are successfully saved, false otherwise.</returns>
        bool Save();
    }

}
