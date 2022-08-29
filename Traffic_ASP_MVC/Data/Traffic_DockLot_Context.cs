using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Data
{
    public class Traffic_DockLot_Context : DbContext
    {
        public Traffic_DockLot_Context (DbContextOptions<Traffic_DockLot_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.DockLot> DockLot { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Doors> Doors { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Carriers> Carriers { get; set; } = default!;
    }
}
