namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an BookGenere the system.
    /// </summary>
    public class BookGenere
    {
        public int BookId { get; set; }
        public int GenereId { get; set; }

        public Book Book { get; set; }

        public Generes Genere { get; set; }
    }
}
