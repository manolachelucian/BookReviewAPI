using ReviewApp.Models;

namespace ReviewApp.Interface
{
    public interface IAuthorInterface
    {
        ICollection<Author> GetAuthors();
        Author GetAuthor(int id);

        ICollection<Book> GetAuthorByBook(int IdAuthor);
         
        bool AuthorExists(int id);

    }
}
