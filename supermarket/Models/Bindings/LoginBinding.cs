using System.ComponentModel.DataAnnotations;

namespace supermarket.Models.Bindings
{
    public class LoginBinding
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}