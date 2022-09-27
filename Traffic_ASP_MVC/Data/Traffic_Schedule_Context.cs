using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.Data
{
    public class Traffic_Schedule_Context : DbContext
    {
        public Traffic_Schedule_Context (DbContextOptions<Traffic_Schedule_Context> options)
            : base(options)
        {
        }

        public DbSet<Traffic_ASP_MVC.Models.Schedule> Schedule { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Coordinators> Coordinators { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Carriers> Carriers { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Customers> Customers { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.TimeSlots> TimeSlots { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Cities> Cities { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.States> States { get; set; } = default!;

        public DbSet<Traffic_ASP_MVC.Models.Doors> Doors { get; set; } = default!;


    }
}
