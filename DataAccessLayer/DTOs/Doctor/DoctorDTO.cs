using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs.Doctor
{
    public class DoctorDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialty { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
