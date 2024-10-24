using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;


namespace ReviewApp.Repository
{
    /// <summary>
    /// Repository class responsible for handling author-related operations in the database.
    /// Implements the <see cref="IAuthorInterface"/>.
    /// </summary>
    public class AuthorRepository : IAuthorInterface
    {
        private readonly DataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorRepository"/> class with a specific data context.
        /// </summary>
        /// <param name="dataContext">The data context to interact with the database.</param>
        public AuthorRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Checks if an author with a given ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the author.</param>
        /// <returns>True if the author exists, otherwise false.</returns>
        public bool AuthorExists(int id)
        {
            return dataContext.Authors.Any(a => a.Id == id);
        }

        /// <summary>
        /// Adds a new author to the database.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object representing the author to create.</param>
        /// <returns>True if the author is successfully created, otherwise false.</returns>
        public bool CreateAuthor(Author author)
        {
            dataContext.Authors.Add(author);
            return Save();
        }

        /// <summary>
        /// Deletes an existing author from the database.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object representing the author to delete.</param>
        /// <returns>True if the author is successfully deleted, otherwise false.</returns>
        public bool DeleteAuthor(Author author)
        {
            dataContext.Authors.Remove(author);
            return Save();
        }

        /// <summary>
        /// Retrieves a specific author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author.</param>
        /// <returns>The <see cref="Author"/> object if found, otherwise null.</returns>
        public Author GetAuthor(int id)
        {
            return dataContext.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves a collection of books associated with a specific author.
        /// </summary>
        /// <param name="IdAuthor">The ID of the author.</param>
        /// <returns>A collection of <see cref="Book"/> objects written by the given author.</returns>
        public ICollection<Book> GetAuthorByBook(int IdAuthor)
        {
            return dataContext.BookAuthors.Where(ba => ba.AuthorId == IdAuthor)
                .Select(ba => ba.Book).ToList();
        }

        /// <summary>
        /// Retrieves a list of all authors, ordered by their name.
        /// </summary>
        /// <returns>A collection of <see cref="Author"/> objects.</returns>
        public ICollection<Author> GetAuthors()
        {
            return dataContext.Authors.OrderBy(a => a.Name).ToList();
        }

        /// <summary>
        /// Saves any changes made to the database.
        /// </summary>
        /// <returns>True if the save operation is successful, otherwise false.</returns>
        public bool Save()
        {
            var save = dataContext.SaveChanges();
            return save > 0 ? true : false;
        }

        /// <summary>
        /// Updates an existing author in the database.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> object representing the author to update.</param>
        /// <returns>True if the author is successfully updated, otherwise false.</returns>
        public bool UpdateAuthor(Author author)
        {
            dataContext.Authors.Update(author);
            return Save();
        }
    }
}
