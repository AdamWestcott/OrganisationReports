using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<CarbonDbItems> CarbonMitigations { get; set; }
            public DbSet<Organisation> Organisation { get; set; }
            public DbSet<Projects> Carbon { get; set; }
            public DbSet<Social> Social { get; set; }
    }
}
