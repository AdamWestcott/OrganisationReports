using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class CarbonDbItemsDTO
    {
        [Key]
        public string CarbonID { get; set; }
        [Required(ErrorMessage = "Scope Not Entered")]
        public string CarbonScope { get; set; }
        [Required(ErrorMessage = "Kgco2e Amount Not Entered")]
        public string CarbonKgCo2e { get; set; }
    }
}
