using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sports_Ground_Management_System.Models;

namespace Sports_Ground_Management_System.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class AspNetUsers : IdentityUser
    {
        public ICollection<Slot> BookedSlots { get; set; }
    }
}

