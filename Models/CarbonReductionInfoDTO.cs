using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class CarbonReductionInfoDTO
    {
        [Required(ErrorMessage = "Additional Details Not Entered")]
        public string AdditionalDetails { get; set; }
        public string CompletedProjects { get; set; }
        public string UpcomingProjects { get; set; }
        public string OrganisationName { get; set; }
        [Required(ErrorMessage = "End Year Not Entered")]
        [RegularExpression("[0-9]+", ErrorMessage = "Please enter a valid End Year ")]
        public string EndYear { get; set; }
        [Required(ErrorMessage = "Reporting Year Not Entered")]
        [RegularExpression("[0-9]+", ErrorMessage = "Please enter a valid Reporting Year")]
        public string ReportingYear { get; set; }
        [Required(ErrorMessage = "Baseline Year Not Entered")]
        [RegularExpression("[0-9]+", ErrorMessage = "Please enter a valid Baseline Year")]
        public string BaselineYear { get; set; }
        [Required(ErrorMessage = "Total kgCo2e Not Entered")]
        public double Total { get; set; }
        [Required]
        public double BaselineScope1Total { get; set; }
        [Required]
        public double BaselineScope2Total { get; set; }
        [Required]
        public double BaselineScope3Total { get; set; }
        [Required]
        public double BaselineTotal { get; set; }
        [Required(ErrorMessage = "Scope 1 kgCo2e Total Not Entered")]
        public double Scope1Total { get; set; }
        [Required(ErrorMessage = "Scope 2 kgCo2e Total Not Entered")]
        public double Scope2Total { get; set; }
        [Required(ErrorMessage = "Scope 3 kgCo2e Total Not Entered")]
        public double Scope3Total { get; set; }
        public double AchievedReduction { get; set; }
        [Required(ErrorMessage = "Predicted  Five Year KgCO2e Reduction Not Entered")]
        public double PredictedFiveYearReduction { get; set; }
    }
}
