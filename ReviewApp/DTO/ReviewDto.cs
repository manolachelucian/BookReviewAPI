using ReviewApp.Models;

namespace ReviewApp.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for transferring author data between the API and client.
    /// </summary>
    public class ReviewDto
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
