using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework02
{
    public class OrganizerProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; } = null!;
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        // Foreign Key & Navigation (Slide 16: One-to-One dependent side)
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
    }
}
