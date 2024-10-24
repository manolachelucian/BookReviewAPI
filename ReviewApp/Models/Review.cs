namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an Review in the system.
    /// </summary>
    public class Review
    {
        public int Id { get; set; }

        // Foreign key for Book
        public int BookId { get; set; }
        public Book Book { get; set; }  // Navigation property

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property

        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime PublishedDate { get; set; }


    }
}
