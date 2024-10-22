namespace ReviewApp.Models
{
    public class Generes
    {
        public int Id { get; set; }

        public string NameGenere { get; set; }

        public ICollection<BookGenere> BooksGenere { get; set; }
    }
}
