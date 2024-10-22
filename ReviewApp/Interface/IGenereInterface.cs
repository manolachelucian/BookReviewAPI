using ReviewApp.Models;

namespace ReviewApp.Interface
{
    public interface IGenereInterface
    {
        ICollection<Generes> GetGeneres();

        Generes GetGenere(int id);

        ICollection<Book> GetBooksForGenere(int id);
        bool GenereExists(int id);
    }
}
