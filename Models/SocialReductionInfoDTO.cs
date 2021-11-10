using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SocialReductionInfoDTO
    {
        [Required]
        public string AdditionalDetails { get; set; }
        public string Currency { get; set; }
        public string OrganisationName { get; set; }
        [Required]
        [RegularExpression("[0-9]+", ErrorMessage = "Please enter a valid Reporting Year")]
        public string ReportingYear { get; set; }
        [Required]
        [RegularExpression("[0-9]+", ErrorMessage = "Please enter a valid Baseline Year")]
        public string BaselineYear { get; set; }
        [Required]
        public double BaselineGrowthTotal { get; set; }
        [Required]
        public double BaselineJobTotal { get; set; }
        [Required]
        public double BaselineEnivromentalTotal { get; set; }
        [Required]
        public double BaselineSocialTotal { get; set; }
        [Required]
        public double BaselineInnovationTotal { get; set; }
        [Required]
        public double BaselineTotal { get; set; }
        [Required]
        public double GrowthTotal { get; set; }
        [Required]
        public double JobTotal { get; set; }
        [Required]
        public double EnivromentalTotal { get; set; }
        [Required]
        public double SocialTotal { get; set; }
        [Required]
        public double InnovationTotal { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public double AchievedReduction { get; set; }
        [Required]
        public double PredictedFiveYearReduction { get; set; }
    }
}
