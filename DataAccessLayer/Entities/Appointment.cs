using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required]
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public string? Reason { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }

}
