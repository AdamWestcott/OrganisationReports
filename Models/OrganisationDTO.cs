using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrganisationDTO
    {
        public string OrganisationID { get; set; }

        [Required(ErrorMessage ="Did not enter Name")]
        public string OrganisationName { get; set; }
        [Required (ErrorMessage ="Did not enter Currency")]
        [RegularExpression(@"(?<SYMBOL>[$€£¥ƒ֏؋])", ErrorMessage = "Please enter a valid Currency Symbol")]
        public string OrganisationCurrency { get; set; }

        public string Logo { get; set; }
    }
}
