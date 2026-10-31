using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework02
{
    public class EventHubDbContext : DbContext
    {
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Badge> Badges => Set<Badge>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Way 1: Separate configuration classes (Slide 7)
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());

            // Way 2: Direct inside OnModelCreating (Slide 5 & 37)
            modelBuilder.Entity<Badge>(builder =>
            {
                builder.HasKey(b => b.Id);

                builder.Property(b => b.BadgeNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                // One-to-One: Attendee <-> Badge (Slide 37)
                builder.HasOne(b => b.Attendee)
                    .WithOne(a => a.Badge)
                    .HasForeignKey<Badge>(b => b.AttendeeId);
            });
        }
    }
 }
