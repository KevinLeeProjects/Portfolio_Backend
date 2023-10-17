using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_Backend.EFCore
{
    [Table("login")]
    public class Login
    {
        [Key, Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string salt { get; set; }
    }
}
