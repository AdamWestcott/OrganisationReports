using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CarbonDbItems
    {
        [Key]
        public string CarbonID { get; set; }
        [Required]
        public string CarbonScope { get; set; }
        [Required]
        public string CarbonKgCo2e { get; set; }
    }
}
