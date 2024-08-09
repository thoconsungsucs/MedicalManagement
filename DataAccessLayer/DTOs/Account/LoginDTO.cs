using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs.Account
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
