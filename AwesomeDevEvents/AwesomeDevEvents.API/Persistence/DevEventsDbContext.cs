using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeakers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(e => e.Title)
                    .IsRequired(false);
                e.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(e => e.StartDate)
                    .HasColumnName("start_date");
                e.Property(e => e.EndDate)
                    .HasColumnName("end_date");

                e.HasMany(de => de.Speakers)
                    .WithOne()
                    .HasForeignKey(de => de.DevEventId);
            });

            builder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(de => de.Id);
            });
        }


    }
}
