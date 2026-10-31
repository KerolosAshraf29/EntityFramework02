using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework02
{
    public class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = null!;
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        // Foreign Key & Navigation (Slide 37: HasForeignKey specifies dependent side)
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}
