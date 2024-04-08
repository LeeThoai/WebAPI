namespace WebAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
