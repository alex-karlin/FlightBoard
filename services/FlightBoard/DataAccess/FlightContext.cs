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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureEntity(modelBuilder.Entity<Aircraft>());
        ConfigureEntity(modelBuilder.Entity<Airline>());
        ConfigureEntity(modelBuilder.Entity<Airport>());
        ConfigureEntity(modelBuilder.Entity<DepartureSchedule>());
        ConfigureEntity(modelBuilder.Entity<Flight>());
    }

    private static void ConfigureEntity(EntityTypeBuilder<Aircraft> builder)
    {
        builder.Property(e => e.Manufacturer).IsRequired();
        builder.Property(e => e.Model).IsRequired();
    }

    private static void ConfigureEntity(EntityTypeBuilder<Airline> builder)
    {
        builder.Property(e => e.Name).IsRequired();
    }

    private static void ConfigureEntity(EntityTypeBuilder<Airport> builder)
    {
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Address).IsRequired(false);
    }

    private static void ConfigureEntity(EntityTypeBuilder<DepartureSchedule> builder)
    {
        builder.HasOne(e => e.Flight)
            .WithMany()
            .HasForeignKey(e => e.FlightId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.Gate).IsRequired();
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
    }

    public DbSet<Aircraft> Aircraft { get; set; } = null!;
    public DbSet<Airline> Airlines { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<DepartureSchedule> DepartureSchedules { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
}