using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;


namespace Traffic_ASP_MVC.Data
{
    public class Traffic_Coordinators_Context : DbContext
    {
        public Traffic_Coordinators_Context (DbContextOptions<Traffic_Coordinators_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.Coordinators> Coordinators { get; set; } = default!;
    }
}
