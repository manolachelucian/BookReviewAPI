using ReviewApp.Data;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class BookRepository : IBookInterface
    {
        private readonly DataContext context;

        public BookRepository(DataContext context)
        {
            this.context = context;
        }

        public bool BookExists(int id)
        {
            return context.Books.Any(b => b.Id == id);
        }

        public Book GetBook(int id)
        {
            return context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBook(string title)
        {
            return context.Books.Where(b => b.Title == title).FirstOrDefault();
        }

        public decimal GetBookRating(int id)
        {
            var review = context.Reviews.Where(r => r.BookId == id).ToList();
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());


            
        }

        public ICollection<Book> GetBooks()
        {
            return context.Books.OrderBy(b => b.Id).ToList();
        }
    }
}
