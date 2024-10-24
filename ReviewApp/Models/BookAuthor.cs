namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an BookAuthor in the system.
    /// </summary>
    public class BookAuthor
    {

        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }

        public Author Author { get; set; }
    }
}
