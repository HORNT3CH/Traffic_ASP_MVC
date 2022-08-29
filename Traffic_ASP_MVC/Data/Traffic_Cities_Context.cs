using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Data
{
    public class Traffic_Cities_Context : DbContext
    {
        public Traffic_Cities_Context (DbContextOptions<Traffic_Cities_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.Cities> Cities { get; set; } = default!;
    }
}
