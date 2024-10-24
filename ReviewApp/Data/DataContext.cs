using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data
{
    /// <summary>
    /// DataContext class for configuring the database context.
    /// This class handles the DbSets (tables) for Reviews, Authors, Books, Genres, Users, and many-to-many relationships between Books and Authors, and Books and Generes.
    /// Inherits from the Entity Framework's <see cref="DbContext"/>.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class with the provided DbContext options.
        /// </summary>
        /// <param name="options">Options for configuring the context.</param>
        public DataContext(DbContextOptions<DataContext> options ): base(options)
        {

        }

        //Entities
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Generes> Genres { get; set; }    
        public DbSet<User> Users { get; set; }

        //Book Relations Many to Many
        public DbSet<BookGenere> BookGeneres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        /// <summary>
        /// Configures the relationships and constraints for the models using Fluent API.
        /// </summary>
        /// <param name="modelBuilder">Provides a simple API for configuring models.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many Book Author
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            //Many to Many Book Genere
            modelBuilder.Entity<BookGenere>()
                .HasKey(bg => new { bg.BookId, bg.GenereId });
            modelBuilder.Entity<BookGenere>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenere)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenere>()
                .HasOne(bg => bg.Genere)
                .WithMany(g => g.BooksGenere)
                .HasForeignKey(bg => bg.GenereId);



            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)  
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews) 
                .HasForeignKey(r => r.UserId);

        }
    }
}
