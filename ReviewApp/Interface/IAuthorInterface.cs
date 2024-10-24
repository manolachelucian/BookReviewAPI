using ReviewApp.Models;

namespace ReviewApp.Interface
{
    /// <summary>
    /// Interface defining the operations for handling authors in the system.
    /// </summary>
    public interface IAuthorInterface
    {
        /// <summary>
        /// Retrieves a collection of all authors.
        /// </summary>
        /// <returns>A collection of <see cref="Author"/> objects.</returns>
        ICollection<Author> GetAuthors();

        /// <summary>
        /// Retrieves a specific author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to retrieve.</param>
        /// <returns>An <see cref="Author"/> object if found, otherwise null.</returns>
        Author GetAuthor(int id);

        /// <summary>
        /// Retrieves a collection of books associated with a specific author.
        /// </summary>
        /// <param name="IdAuthor">The ID of the author whose books to retrieve.</param>
        /// <returns>A collection of <see cref="Book"/> objects authored by the given author.</returns>
        ICollection<Book> GetAuthorByBook(int IdAuthor);

        /// <summary>
        /// Checks if an author with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the author to check.</param>
        /// <returns>True if the author exists, otherwise false.</returns>
        bool AuthorExists(int id);

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object representing the new author.</param>
        /// <returns>True if the author is successfully created, otherwise false.</returns>
        bool CreateAuthor(Author author);

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object containing updated author details.</param>
        /// <returns>True if the author is successfully updated, otherwise false.</returns>
        bool UpdateAuthor(Author author);

        /// <summary>
        /// Deletes an author from the Database.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object representing the author to delete.</param>
        /// <returns>True if the author is successfully deleted, otherwise false.</returns>
        bool DeleteAuthor(Author author);

        /// <summary>
        /// Saves any pending changes to the data source.
        /// </summary>
        /// <returns>True if the save operation is successful, otherwise false.</returns>
        bool Save();
    }

}
