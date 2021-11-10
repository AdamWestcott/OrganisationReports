using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SocialDTO
    {
            public string SocialID { get; set; }
            [Required]
            public string SocialName { get; set; }
            [Required]
            public string SocialDescription { get; set; }
            [Required]
            public string Theme { get; set; }
            [Required]
            public string Category { get; set; }
            public string SocialType { get; set; }
            [Required]
            public string SocialProgress { get; set; }
            [Required]
            public DateTime SocialStartDate { get; set; }
            [Required]
            public DateTime SocialEndDate { get; set; }
            [Required]
            public double SocialValue { get; set; }
            public string OrganisationID { get; set; }

            [Required(ErrorMessage = "Period Of Measurement Not Set")]
            public string PeriodOfMeasurement { get; set; }
            [Required(ErrorMessage = "Yearly SocialValue not set")]
            public double YearlySocialValue { get; set; }

    }
}
