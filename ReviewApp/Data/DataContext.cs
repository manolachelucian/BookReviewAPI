using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data
{
    public class DataContext : DbContext
    {
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
