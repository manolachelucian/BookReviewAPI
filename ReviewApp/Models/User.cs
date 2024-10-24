namespace ReviewApp.Models
{
    /// <summary>
    /// Entity model representing an User in the system.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
