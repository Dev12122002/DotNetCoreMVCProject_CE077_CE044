using System;
using System.Data.Entity;
using ApplicationSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sports_Ground_Management_System.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Sports_Ground_Management_System.Areas.Identity.IdentityHostingStartup))]
namespace Sports_Ground_Management_System.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));
                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
                //services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(
                //        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));
                //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                //     .AddDefaultUI()
                //     .AddEntityFrameworkStores<ApplicationDbContext>()
                //     .AddDefaultTokenProviders();
                //services.AddControllersWithViews();
                //services.AddRazorPages();
            });

        }
    }
}