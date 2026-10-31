using Microsoft.EntityFrameworkCore;

namespace EntityFramework02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EventHubDbContext())
            {
                context.Database.EnsureCreated();

                // 1. Add an Organizer with a Profile and an Event
                var org = new Organizer
                {
                    Name = "Tech Route",
                    CompanyName = "Route Academy",
                    IsVerified = true,
                    Profile = new OrganizerProfile
                    {
                        Bio = "Education & Tech Event Organizer"
                    },
                    Events = new List<Event>
        {
            new Event
            {
                Title = "EF Core ",
                Description = " EF Core 10",
                StartDate = DateTime.Now.AddDays(7),
                MaxAttendees = 100
            }
        }
                };

                // 2. Add an Attendee with a Badge
                var attendee = new Attendee
                {
                    FullName = "Ahmed Ali",
                    Email = "ahmed@example.com",
                    Street = "El-Haram St",
                    City = "Giza",
                    Country = "Egypt",
                    PostalCode = "12511",
                    Badge = new Badge
                    {
                        BadgeNumber = "VIP-001",
                        IssuedDate = DateTime.Now,
                        Tier = BadgeTier.VIP
                    }
                };

                context.Organizers.Add(org);
                context.Attendees.Add(attendee);

                context.SaveChanges();

                Console.WriteLine("Database and sample data created successfully!");
                Console.WriteLine($"Saved Attendee Address: {attendee.FullAddress}");
            }
        }
    }
}
