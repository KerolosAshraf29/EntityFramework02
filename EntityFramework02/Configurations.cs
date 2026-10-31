using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EntityFramework02
{
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Bio)
                .IsRequired()
                .HasMaxLength(500);

            // One-to-One: Organizer <-> OrganizerProfile (Slide 37)
            builder.HasOne(p => p.Organizer)
                .WithOne(o => o.Profile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        }
    }

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            // One-to-Many: Organizer -> Events (Slide 7 & 14)
            builder.HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId);
        }
    }
}
