using System.Runtime;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class FlightContext : DbContext
{
    public FlightContext(DbContextOptions<FlightContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureEntity(modelBuilder.Entity<Aircraft>());
        ConfigureEntity(modelBuilder.Entity<Airline>());
        ConfigureEntity(modelBuilder.Entity<Airport>());
        ConfigureEntity(modelBuilder.Entity<Flight>());
        ConfigureEntity(modelBuilder.Entity<DepartureSchedule>());
    }

    private static void ConfigureEntity(EntityTypeBuilder<Aircraft> builder)
    {
        builder.Property(e => e.Manufacturer).IsRequired();
        builder.Property(e => e.Model).IsRequired();
        builder.HasData(new List<Aircraft>
        {
            new()
            {
                AircraftId = 1,
                Manufacturer = "Boeing",
                Model = "787-9",
                Capacity = 294
            },
            new()
            {
                AircraftId = 2,
                Manufacturer = "Boeing",
                Model = "777-300ER",
                Capacity = 332
            },
            new()
            {
                AircraftId = 3,
                Manufacturer = "Airbus",
                Model = "A320",
                Capacity = 171
            }
        });
    }

    private static void ConfigureEntity(EntityTypeBuilder<Airline> builder)
    {
        builder.Property(e => e.Name).IsRequired();
        builder.HasData(new List<Airline>
        {
            new()
            {
                AirlineId = 1,
                Name = "Air New Zealand"
            }
        });
    }

    private static void ConfigureEntity(EntityTypeBuilder<Airport> builder)
    {
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Address).IsRequired(false);
        builder.HasData(new List<Airport>
        {
            new()
            {
                AirportId = 1,
                Name = "Christchurch Airport",
                Address = "30 Durey Road, Christchurch 8053"
            },
            new()
            {
                AirportId = 2,
                Name = "Queenstown Airport",
                Address = "Sir Henry Wigley Drive, Frankton, Queenstown 9300"
            },
            new()
            {
                AirportId = 3,
                Name = "Auckland Airport",
                Address = "Ray Emery Drive, Māngere, Auckland 2022"
            },
        });
    }

    private static void ConfigureEntity(EntityTypeBuilder<Flight> builder)
    {
        builder.HasOne(e => e.Airline)
            .WithMany()
            .HasForeignKey(e => e.AirlineId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Aircraft)
            .WithMany()
            .HasForeignKey(e => e.AircraftId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(e => e.Number).IsRequired();
        builder.HasOne(e => e.Source)
            .WithMany()
            .HasForeignKey(e => e.SourceId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Destination)
            .WithMany()
            .HasForeignKey(e => e.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(e => e.Status).HasConversion(
            value => value.ToString(),
            value => (FlightStatus)Enum.Parse(typeof(FlightStatus), value));
        builder.HasData(new List<Flight>
        {
            new()
            {
                FlightId = 1,
                AirlineId = 1,
                AircraftId = 3,
                Number = "NZ5659",
                SourceId = 1,
                DestinationId = 2,
                Status = FlightStatus.OnTime
            },
            new()
            {
                FlightId = 2,
                AirlineId = 1,
                AircraftId = 3,
                Number = "NZ5647",
                SourceId = 1,
                DestinationId = 2,
                Status = FlightStatus.OnTime
            },
            new()
            {
                FlightId = 3,
                AirlineId = 1,
                AircraftId = 3,
                Number = "NZ5653",
                SourceId = 1,
                DestinationId = 2,
                Status = FlightStatus.OnTime
            },
            new()
            {
                FlightId = 4,
                AirlineId = 1,
                AircraftId = 3,
                Number = "NZ643",
                SourceId = 1,
                DestinationId = 2,
                Status = FlightStatus.OnTime
            },
        });
    }

    private static void ConfigureEntity(EntityTypeBuilder<DepartureSchedule> builder)
    {
        builder.HasOne(e => e.Flight)
            .WithMany()
            .HasForeignKey(e => e.FlightId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.Actual).IsRequired(false);
        builder.Property(e => e.Gate).IsRequired();
        builder.HasData(new List<DepartureSchedule>
        {
            new()
            {
                DepartureScheduleId = 1,
                FlightId = 1,
                Scheduled = new DateTime(2022, 8, 3, 8, 40, 0),
                Estimated = new DateTime(2022, 8, 3, 8, 40, 0),
                Gate = "30"
            },
            new()
            {
                DepartureScheduleId = 2,
                FlightId = 2,
                Scheduled = new DateTime(2022, 8, 3, 11, 5, 0),
                Estimated = new DateTime(2022, 8, 3, 11, 5, 0),
                Gate = "28"
            },
            new()
            {
                DepartureScheduleId = 3,
                FlightId = 2,
                Scheduled = new DateTime(2022, 8, 4, 11, 5, 0),
                Estimated = new DateTime(2022, 8, 4, 11, 5, 0),
                Gate = "28"
            },
            new()
            {
                DepartureScheduleId = 4,
                FlightId = 3,
                Scheduled = new DateTime(2022, 8, 3, 14, 40, 0),
                Estimated = new DateTime(2022, 8, 3, 14, 40, 0),
                Gate = "19"
            }
        });
    }

    public DbSet<Aircraft> Aircraft { get; set; } = null!;
    public DbSet<Airline> Airlines { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<DepartureSchedule> DepartureSchedules { get; set; } = null!;
}