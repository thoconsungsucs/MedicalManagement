using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Doctor : ApplicationUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialty { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
