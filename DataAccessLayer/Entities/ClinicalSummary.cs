using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class ClinicalSummary
    {
        public int ClinicalSummaryId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }

        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
    }
}
