using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Data
{
    public class Traffic_Customers_Context : DbContext
    {
        public Traffic_Customers_Context (DbContextOptions<Traffic_Customers_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.Customers> Customers { get; set; } = default!;
    }
}
