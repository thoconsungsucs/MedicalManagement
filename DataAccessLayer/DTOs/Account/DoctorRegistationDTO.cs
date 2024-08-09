using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs.Account
{
    public class DoctorRegistationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
