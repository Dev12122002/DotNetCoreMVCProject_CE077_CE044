using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sports_Ground_Management_System.Models
{
    public class Ground
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string img { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public long capacity { get; set; }

        public ICollection<BookedSlot> BookedSlots { get; set; }
    }
}
