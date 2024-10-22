using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;


namespace ReviewApp.Repository
{
    public class AuthorRepository : IAuthorInterface
    {
        private readonly DataContext dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public bool AuthorExists(int id)
        {
            return dataContext.Authors.Any(a => a.Id == id);
        }


        public Author GetAuthor(int id)
        {
            return dataContext.Authors.Where(a => a.Id == id).FirstOrDefault();

        }

        public ICollection<Book> GetAuthorByBook(int IdAuthor)
        {
            return dataContext.BookAuthors.Where(ba => ba.AuthorId == IdAuthor).Select(ba => ba.Book).ToList();
        }

        public ICollection<Author> GetAuthors()
        {
            return dataContext.Authors.OrderBy(a => a.Name).ToList();
        }
    }
}
