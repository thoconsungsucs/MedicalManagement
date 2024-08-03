using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Medication
    {
        public int MedicationId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
