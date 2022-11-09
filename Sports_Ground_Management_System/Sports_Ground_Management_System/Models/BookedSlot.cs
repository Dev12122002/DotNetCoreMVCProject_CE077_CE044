using Sports_Ground_Management_System.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sports_Ground_Management_System.Models
{
    public class BookedSlot
    {
        public int Id { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        public int GroundId { get; set; }

        public Ground Ground { get; set; }

        //[Required]
        //public IEnumerable<Ground> Grounds { get; set; }

        public ApplicationUser User { get; set; }
    }
}
