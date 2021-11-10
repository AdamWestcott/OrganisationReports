using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Organisation
    {
        [Key]
        public string OrganisationID { get; set; }
        [Required]
        public string OrganisationName { get; set; }
        [Required]
        public string OrganisationCurrency { get; set; }
        [Required]
        public string Logo { get; set; }
    }
}
