namespace ReviewApp.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for transferring author data between the API and client.
    /// </summary>
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
