using ReviewApp.Data;
using ReviewApp.Models;

namespace ReviewApp
{

    /// <summary>
    /// Class responsible for seeding initial data into the database context.
    /// </summary>
    public class Seed
    {
        private readonly DataContext _dataContext;


        /// <summary>
        /// Initializes a new instance of the <see cref="Seed"/> class.
        /// </summary>
        /// <param name="context">The database context to be seeded.</param>
        public Seed(DataContext context)
        {
            this._dataContext = context;
        }
        /// <summary>
        /// Seeds the database context with initial data, if the tables are empty.
        /// </summary>
        public void SeedDataContext()
        {
            if (!_dataContext.BookAuthors.Any() && !_dataContext.BookGeneres.Any() && !_dataContext.Reviews.Any() && !_dataContext.Users.Any())
            {
                
                var users = new List<User>()
                {
                    new User { Username = "John Doe" },
                    new User { Username = "Jane Smith" }
                };

                _dataContext.Users.AddRange(users);
                _dataContext.SaveChanges();

                var generes = new List<Generes>()
                {
                    new Generes { NameGenere = "Classic" },
                    new Generes { NameGenere = "Dystopian" },
                    new Generes { NameGenere = "Adventure" }
                };

                _dataContext.Genres.AddRange(generes);
                _dataContext.SaveChanges();

                var bookAuthors = new List<BookAuthor>()
                {
                    new BookAuthor
                    {
                        Book = new Book()
                        {
                            Title = "The Great Gatsby",
                            PublishedYear = new DateTime(1925, 4, 10),
                            Reviews = new List<Review>(),
                            BookAuthors = new List<BookAuthor>(),
                            BookGenere = new List<BookGenere>()
                        },
                        Author = new Author()
                        {
                            Name = "F. Scott Fitzgerald"
                        }
                    },
                    new BookAuthor
                    {
                        Book = new Book()
                        {
                            Title = "1984",
                            PublishedYear = new DateTime(1949, 6, 8),
                            Reviews = new List<Review>(),
                            BookAuthors = new List<BookAuthor>(),
                            BookGenere = new List<BookGenere>()
                        },
                        Author = new Author()
                        {
                            Name = "George Orwell"
                        }
                    },
                    new BookAuthor
                    {
                        Book = new Book()
                        {
                            Title = "Moby Dick",
                            PublishedYear = new DateTime(1851, 10, 18),
                            Reviews = new List<Review>(),
                            BookAuthors = new List<BookAuthor>(),
                            BookGenere = new List<BookGenere>()
                        },
                        Author = new Author()
                        {
                            Name = "Herman Melville"
                        }
                    }
                };

                _dataContext.BookAuthors.AddRange(bookAuthors);

              
                var bookGeneres = new List<BookGenere>()
                {
                    new BookGenere
                    {
                        Book = bookAuthors[0].Book,
                        Genere = generes.First(g => g.NameGenere == "Classic")
                    },
                    new BookGenere
                    {
                        Book = bookAuthors[1].Book,
                        Genere = generes.First(g => g.NameGenere == "Dystopian")
                    },
                    new BookGenere
                    {
                        Book = bookAuthors[2].Book,
                        Genere = generes.First(g => g.NameGenere == "Adventure")
                    }
                };

                _dataContext.BookGeneres.AddRange(bookGeneres);
                _dataContext.SaveChanges();

                // Create reviews
                var reviews = new List<Review>()
                {
                    new Review
                    {
                        Book = bookAuthors[0].Book,
                        User = users[0],  
                        ReviewText = "A timeless classic that captures the essence of the American dream.",
                        Rating = 5,
                        PublishedDate = DateTime.Now
                    },
                    new Review
                    {
                        Book = bookAuthors[1].Book,
                        User = users[1],  
                        ReviewText = "A chilling vision of a dystopian future.",
                        Rating = 4,
                        PublishedDate = DateTime.Now
                    },
                    new Review
                    {
                        Book = bookAuthors[2].Book,
                        User = users[0],  
                        ReviewText = "An epic tale of adventure and obsession.",
                        Rating = 5,
                        PublishedDate = DateTime.Now
                    }
                };

                _dataContext.Reviews.AddRange(reviews);
                _dataContext.SaveChanges();
            }
        }


    }
}
