using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class SocialReductionInfo
    {
        [Required]
        public string AdditionalDetails { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string OrganisationName { get; set; }
        [Required]
        public string ReportingYear { get; set; }
        [Required]
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
