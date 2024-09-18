using System.ComponentModel;

namespace Core.Dtos
{
    public class LoginDto
    {
        [DefaultValue("v@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("Asd123-")]
        public string Password { get; set; }
    }
}
