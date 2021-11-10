using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProjectsDTO
    {
        [Key]
        public string CarbonID { get; set; }
        [Required(ErrorMessage = "Name Not Entered")]
        public string CarbonName { get; set; }
        [Required(ErrorMessage = "Description Not Entered")]
        public string CarbonDescription { get; set; }
        [Required(ErrorMessage = "Scope Not Chosen")]
        public string CarbonScope { get; set; }
        public string CarbonType { get; set; }
        public string CarbonProgress { get; set; }
        [Required(ErrorMessage = "Start Date Not chosen")]
        public DateTime CarbonStartDate { get; set; }
        [Required(ErrorMessage = "End Date Not chosen")]
        public DateTime CarbonEndDate { get; set; }
        [Required(ErrorMessage = "KgCo2e amount Not entered")]
        public double KgCo2e { get; set; }
        public string OrganisationID { get; set; }
        [Required(ErrorMessage = "Period Of Measurement Not Set")]
        public string PeriodOfMeasurement { get; set; }
        [Required(ErrorMessage = "Yearly KgCo2e is not Set")]
        public double YearlyKgCo2e { get; set; }

    }
}
