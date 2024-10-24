namespace ReviewApp.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for transferring author data between the API and client.
    /// </summary>
    
    
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedYear { get; set; }
    }
}
