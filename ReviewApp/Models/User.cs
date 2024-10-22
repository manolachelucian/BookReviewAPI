namespace ReviewApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
