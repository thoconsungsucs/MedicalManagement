using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public int MedicationId { get; set; }
        [Required]
        public int MedicalReportId { get; set; }
        [ForeignKey("MedicationId")]
        public Medication Medication { get; set; }
        [ForeignKey("MedicalReportId")]
        public MedicalReport MedicalReport { get; set; }
    }

}
