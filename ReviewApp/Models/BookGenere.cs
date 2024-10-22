namespace ReviewApp.Models
{
    public class BookGenere
    {
        public int BookId { get; set; }
        public int GenereId { get; set; }

        public Book Book { get; set; }

        public Generes Genere { get; set; }
    }
}
