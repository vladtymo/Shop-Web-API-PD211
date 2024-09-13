namespace Core.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
