using System.ComponentModel.DataAnnotations;

namespace supermarket.Models.Bindings
{
    public class UserBinding
    {
        [Required, Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required, Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required, Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}