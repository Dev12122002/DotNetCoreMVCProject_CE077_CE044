using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sports_Ground_Management_System.Areas.Identity.Data;
using Sports_Ground_Management_System.Models;

    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext (DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        //public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Sports_Ground_Management_System.Models.Ground> Ground { get; set; }

        public DbSet<Sports_Ground_Management_System.Models.Slot> BookedSlot { get; set; }
    }
