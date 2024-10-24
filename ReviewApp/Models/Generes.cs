namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an Generes in the system.
    /// </summary>
    public class Generes
    {
        public int Id { get; set; }

        public string NameGenere { get; set; }

        public ICollection<BookGenere> BooksGenere { get; set; }
    }
}
