using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
   public class Projects
    {
        [Key]
        public string CarbonID { get; set; }
        [Required]
        public string CarbonName { get; set; }
        [Required]
        public string CarbonDescription { get; set; }
        [Required]
        public string CarbonScope { get; set; }
        [Required]
        public string CarbonType { get; set; }
        [Required]
        public string CarbonProgress { get; set; }
        [Required]
        public DateTime CarbonStartDate { get; set; }
        [Required]
        public DateTime CarbonEndDate { get; set; }
        [Required]
        public double KgCo2e { get; set; }
        [Required]
        public string OrganisationID { get; set; }

        [Required]
        public string PeriodOfMeasurement { get; set; }
        [Required]
        public double YearlyKgCo2e { get; set; }
    }
}
