using System.ComponentModel.DataAnnotations;

namespace MVC_Roles.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Обнаружена несоответствие пароля")]
        public string? RepeatPassword { get; set; }
        public Roles? Roles { get; set; }
    }
}
