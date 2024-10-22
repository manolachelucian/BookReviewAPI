using ReviewApp.Models;

namespace ReviewApp.Interface
{
    public interface IBookInterface
    {
        ICollection<Book> GetBooks();

        Book GetBook(int id);

        Book GetBook(string title);

        decimal GetBookRating(int id);

        bool BookExists(int id);    



    }
}
