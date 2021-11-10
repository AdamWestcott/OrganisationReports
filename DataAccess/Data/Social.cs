using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Social
    {
        [Key]
        public string SocialID { get; set; }
        [Required]
        public string SocialName { get; set; }
        [Required]
        public string SocialDescription { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string SocialType { get; set; }
        [Required]
        public string SocialProgress { get; set; }
        [Required]
        public DateTime SocialStartDate { get; set; }
        [Required]
        public DateTime SocialEndDate { get; set; }
        [Required]
        public double SocialValue { get; set; }
        [Required]
        public string OrganisationID { get; set; }
        [Required]
        public string PeriodOfMeasurement { get; set; }
        [Required]
        public double YearlySocialValue { get; set; }

    }
}
