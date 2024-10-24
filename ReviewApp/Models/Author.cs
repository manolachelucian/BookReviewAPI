namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an author in the system.
    /// </summary>
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
