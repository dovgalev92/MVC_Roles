using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MVC_Roles.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string City { get; set; } = string.Empty;
        public Roles? Roles { get; set; }
    }
}
