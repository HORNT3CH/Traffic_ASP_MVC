using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Data
{
    public class Traffic_Carriers_Context : DbContext
    {
        public Traffic_Carriers_Context (DbContextOptions<Traffic_Carriers_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.Carriers> Carriers { get; set; } = default!;
    }
}
