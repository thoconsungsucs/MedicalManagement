using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class MedicalReport
    {
        public int MedicalReportId { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        [Required]
        public int ClinicalSummaryId { get; set; }
        public ClinicalSummary ClinicalSummary { get; set; }
    }
}
