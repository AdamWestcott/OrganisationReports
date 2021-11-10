using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class CarbonReductionInfo
    {
        [Required]
        public string AdditionalDetails { get; set; }
        [Required]
        public string CompletedProjects { get; set; }
        [Required]
        public string UpcomingProjects { get; set; }
        [Required]
        public string OrganisationName { get; set; }
        [Required]
        public string EndYear { get; set; }
        [Required]
        public string ReportingYear { get; set; }
        [Required]
        public string BaselineYear { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public double BaselineScope1Total { get; set; }
        [Required]
        public double BaselineScope2Total { get; set; }
        [Required]
        public double BaselineScope3Total { get; set; }
        [Required]
        public double BaselineTotal { get; set; }
        [Required]
        public double Scope1Total { get; set; }
        [Required]
        public double Scope2Total { get; set; }
        [Required]
        public double Scope3Total { get; set; }
        [Required]
        public double AchievedReduction { get; set; }
        [Required]
        public double PredictedFiveYearReduction { get; set; }



    }
}
