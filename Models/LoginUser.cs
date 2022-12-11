using System.ComponentModel.DataAnnotations;

namespace MVC_Roles.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
