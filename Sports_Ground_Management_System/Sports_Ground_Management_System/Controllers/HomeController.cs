using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sports_Ground_Management_System.Areas.Identity.Data;
using Sports_Ground_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationSystem.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sports_Ground_Management_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<HomeController> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ServiceCollection sc = new ServiceCollection();
            ServiceProvider serviceProvider = sc.BuildServiceProvider();
            await Initialize(serviceProvider);
            return LocalRedirect("~/Grounds");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleName = "Admin";
            IdentityResult result;
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                result = await _roleManager
                    .CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    var admin = await _userManager
                        .FindByEmailAsync("admin@gmail.com");

                    if (admin == null)
                    {  
                        var user = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                        result = await _userManager.CreateAsync(user, "Admin@1212");
                       
                        if (result.Succeeded)
                        {
                            result = await _userManager
                                .AddToRoleAsync(user, roleName);
                        }
                    }
                }
            }
        }

        //public Task GetUser()
        //{
        //    var user = _userManager.FindById(User.Identity.GetUserId());
        //    return user;
        //}

    }
}
