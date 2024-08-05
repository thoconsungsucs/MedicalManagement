using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Patient : ApplicationUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

}
