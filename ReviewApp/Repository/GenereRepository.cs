using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class GenereRepository : IGenereInterface
    {
        private readonly DataContext dataContext;

        public GenereRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public bool GenereExists(int id)
        {
            return dataContext.Genres.Any(g => g.Id == id);
        }

        public ICollection<Book> GetBooksForGenere(int id)
        {
            return dataContext.BookGeneres.Where(bg => bg.GenereId == id).Select(b => b.Book).ToList();
        }

        public Generes GetGenere(int id)
        {
            return dataContext.Genres.Where(g => g.Id == id).FirstOrDefault();
        }

        public Generes GetGenere(string name)
        {
            return dataContext.Genres.Where(g => g.NameGenere == name).FirstOrDefault();
        }

        public ICollection<Generes> GetGeneres()
        {
            return dataContext.Genres.OrderBy(g => g.NameGenere).ToList();
        }
    }
}
