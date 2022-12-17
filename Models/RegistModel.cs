using System.ComponentModel.DataAnnotations;

namespace MVC_Roles.Models
{
    public class RegistModel
    {
        [Required(ErrorMessage = "Укажите Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string? ConfirmPassword { get; set; }
        public string CityUser { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
