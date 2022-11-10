using ApplicationSystem.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Sports_Ground_Management_System.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sports_Ground_Management_System.Models
{
    public class Slot
    {
        public int Id { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        [Required]
        public long Attendees { get; set; }

        public int GroundId { get; set; }

        public Ground Ground { get; set; }

        public string UserId { get; set; }

        public AspNetUsers User { get; set; }

        //[NotMapped]
        //public virtual ApplicationUser User => new ApplicationDbContext().Users.Find(UserId);

        //[NotMapped]
        //public List<ApplicationUser> Users => getGuestUsers();

        //private List<ApplicationUser> getGuestUsers()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    List<ApplicationUser> users = db.Users.ToList();
        //    //List<ApplicationUser> newUsers = new List<ApplicationUser>();

        //    //var role = db.Roles.Where(m => m.Name == "Guest").FirstOrDefault();

        //    //foreach (var item in users)
        //    //{
        //    //    if (item.Roles.FirstOrDefault().RoleId == role.Id)
        //    //    {
        //    //        newUsers.Add(item);
        //    //    }
        //    //}

        //    return users;

        //}
    }
}
