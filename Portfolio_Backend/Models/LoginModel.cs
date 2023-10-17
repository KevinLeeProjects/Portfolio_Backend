

using System.ComponentModel.DataAnnotations;

namespace Portfolio_Backend.Models
{
    public class LoginModel
    {
        [Key, Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string salt { get; set; }
    }
}
